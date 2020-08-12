﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs.Memory.Scopes;
using Newtonsoft.Json.Linq;

namespace Microsoft.Bot.Builder.Dialogs.Memory
{
    /// <summary>
    /// The DialogStateManager manages memory scopes and pathresolvers
    /// MemoryScopes are named root level objects, which can exist either in the dialogcontext or off of turn state
    /// PathResolvers allow for shortcut behavior for mapping things like $foo -> dialog.foo.
    /// </summary>
#pragma warning disable CA1710 // Identifiers should have correct suffix (We can't rename this class without breaking binary compat)
    public class DialogStateManager : IDictionary<string, object>
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        /// <summary>
        /// Information for tracking when path was last modified.
        /// </summary>
        private const string PathTracker = "dialog._tracker.paths";

        private static readonly char[] Separators = { ',', '[' };

        private readonly DialogContext _dialogContext;
        private int _version;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogStateManager"/> class.
        /// </summary>
        /// <param name="dc">The dialog context.</param>
        /// <param name="configuration">The dialog state manager configuration.</param>
        public DialogStateManager(DialogContext dc, DialogStateManagerConfiguration configuration = null)
        {
            ComponentRegistration.Add(new DialogsComponentRegistration());

            _dialogContext = dc ?? throw new ArgumentNullException(nameof(dc));
            Configuration = configuration ?? dc.Context.TurnState.Get<DialogStateManagerConfiguration>();
            if (Configuration == null)
            {
                Configuration = new DialogStateManagerConfiguration();

                // get all of the component memory scopes
                foreach (var component in ComponentRegistration.Components.OfType<IComponentMemoryScopes>())
                {
                    foreach (var memoryScope in component.GetMemoryScopes())
                    {
                        Configuration.MemoryScopes.Add(memoryScope);
                    }
                }

                // get all of the component path resolvers
                foreach (var component in ComponentRegistration.Components.OfType<IComponentPathResolvers>())
                {
                    foreach (var pathResolver in component.GetPathResolvers())
                    {
                        Configuration.PathResolvers.Add(pathResolver);
                    }
                }
            }

            // cache for any other new dialogStatemanager instances in this turn.  
            dc.Context.TurnState.Set(Configuration);
        }

        /// <summary>
        /// Gets or sets the dialog state managers configuration.
        /// </summary>
        /// <value>
        /// The <see cref="DialogStateManagerConfiguration"/>.
        /// </value>
        public DialogStateManagerConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets the keys in the configuration's memory scopes.
        /// </summary>
        /// <value>
        /// A <see cref="ICollection"/> of type string.
        /// </value>
        public ICollection<string> Keys => Configuration.MemoryScopes.Select(ms => ms.Name).ToList();

        /// <summary>
        /// Gets the values in the configuration's memory scopes.
        /// </summary>
        /// <value>
        /// A <see cref="ICollection"/> of type object.
        /// </value>
        public ICollection<object> Values => Configuration.MemoryScopes.Select(ms => ms.GetMemory(_dialogContext)).ToList();

        /// <summary>
        /// Gets the count of the items in the configuration's memory scopes.
        /// </summary>
        /// <value>An int.</value>
        public int Count => Configuration.MemoryScopes.Count;

        /// <summary>
        /// Gets a value indicating whether gets the IsReadOnly property.
        /// </summary>
        /// <value>
        /// A bool.
        /// </value>
        public bool IsReadOnly => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>An object.</returns>
        public object this[string key]
        {
            get => GetValue<object>(key, () => null);
            set
            {
                if (key.IndexOfAny(Separators) == -1)
                {
                    // Root is handled by SetMemory rather than SetValue
                    var scope = GetMemoryScope(key) ?? throw new ArgumentOutOfRangeException(nameof(key), GetBadScopeMessage(key));
                    scope.SetMemory(_dialogContext, JToken.FromObject(value));
                }
                else
                {
                    SetValue(key, value);
                }
            }
        }

        /// <summary>
        /// Get MemoryScope by name.
        /// </summary>
        /// <param name="name">Name of scope.</param>
        /// <returns>A memory scope.</returns>
        public MemoryScope GetMemoryScope(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return Configuration.MemoryScopes.FirstOrDefault(ms => string.Compare(ms.Name, name, StringComparison.OrdinalIgnoreCase) == 0);
        }

        /// <summary>
        /// Version help caller to identify the updates and decide cache or not.
        /// </summary>
        /// <returns>Current version.</returns>
        public string Version()
        {
            return _version.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// ResolveMemoryScope will find the MemoryScope for and return the remaining path.
        /// </summary>
        /// <param name="path">Incoming path to resolve to scope and remaining path.</param>
        /// <param name="remainingPath">Remaining subpath in scope.</param>
        /// <returns>The memory scope.</returns>
        public virtual MemoryScope ResolveMemoryScope(string path, out string remainingPath)
        {
            var scope = path;
            var sepIndex = -1;
            var dot = path.IndexOf(".", StringComparison.OrdinalIgnoreCase);
            var openSquareBracket = path.IndexOf("[", StringComparison.OrdinalIgnoreCase);

            if (dot > 0 && openSquareBracket > 0)
            {
                sepIndex = Math.Min(dot, openSquareBracket);
            }
            else if (dot > 0)
            {
                sepIndex = dot;
            }
            else if (openSquareBracket > 0)
            {
                sepIndex = openSquareBracket;
            }

            if (sepIndex > 0)
            {
                scope = path.Substring(0, sepIndex);
                var memoryScope = GetMemoryScope(scope);
                if (memoryScope != null)
                {
                    remainingPath = path.Substring(sepIndex + 1);
                    return memoryScope;
                }
            }

            remainingPath = string.Empty;
            return GetMemoryScope(scope) ?? throw new ArgumentOutOfRangeException(GetBadScopeMessage(path));
        }

        /// <summary>
        /// Transform the path using the registered PathTransformers.
        /// </summary>
        /// <param name="path">Path to transform.</param>
        /// <returns>The transformed path.</returns>
        public virtual string TransformPath(string path)
        {
            foreach (var pathResolver in Configuration.PathResolvers)
            {
                path = pathResolver.TransformPath(path);
            }

            return path;
        }

        /// <summary>
        /// Get the value from memory using path expression (NOTE: This always returns clone of value).
        /// </summary>
        /// <remarks>This always returns a CLONE of the memory, any modifications to the result of this will not be affect memory.</remarks>
        /// <typeparam name="T">the value type to return.</typeparam>
        /// <param name="path">path expression to use.</param>
        /// <param name="value">Value out parameter.</param>
        /// <returns>True if found, false if not.</returns>
        public bool TryGetValue<T>(string path, out T value)
        {
            value = default;
            path = TransformPath(path ?? throw new ArgumentNullException(nameof(path)));

            MemoryScope memoryScope = null;
            string remainingPath;

            try
            {
                memoryScope = ResolveMemoryScope(path, out remainingPath);
            }
#pragma warning disable CA1031 // Do not catch general exception types (Unable to get the value for some reason, catch, log and return false, ignoring exception)
            catch (Exception err)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                Trace.TraceError(err.Message);
                return false;
            }

            if (memoryScope == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(remainingPath))
            {
                var memory = memoryScope.GetMemory(_dialogContext);
                if (memory == null)
                {
                    return false;
                }

                value = ObjectPath.MapValueTo<T>(memory);
                return true;
            }

            // TODO: HACK to support .First() retrieval on turn.recognized.entities.foo, replace with Expressions once expression ship
            const string first = ".FIRST()";
            var iFirst = path.ToUpperInvariant().LastIndexOf(first, StringComparison.Ordinal);
            if (iFirst >= 0)
            {
                object entity = null;
                remainingPath = path.Substring(iFirst + first.Length);
                path = path.Substring(0, iFirst);
                if (TryGetFirstNestedValue(ref entity, ref path, this))
                {
                    if (string.IsNullOrEmpty(remainingPath))
                    {
                        value = ObjectPath.MapValueTo<T>(entity);
                        return true;
                    }

                    return ObjectPath.TryGetPathValue(entity, remainingPath, out value);
                }

                return false;
            }

            return ObjectPath.TryGetPathValue(this, path, out value);
        }

        /// <summary>
        /// Get the value from memory using path expression (NOTE: This always returns clone of value).
        /// </summary>
        /// <remarks>This always returns a CLONE of the memory, any modifications to the result of this will not be affect memory.</remarks>
        /// <typeparam name="T">The value type to return.</typeparam>
        /// <param name="pathExpression">Path expression to use.</param>
        /// <param name="defaultValue">Function to give default value if there is none (OPTIONAL).</param>
        /// <returns>Result or null if the path is not valid.</returns>
        public T GetValue<T>(string pathExpression, Func<T> defaultValue = null)
        {
            if (TryGetValue<T>(pathExpression ?? throw new ArgumentNullException(nameof(pathExpression)), out var value))
            {
                return value;
            }

            return defaultValue != null ? defaultValue() : default;
        }

        /// <summary>
        /// Get a int value from memory using a path expression.
        /// </summary>
        /// <param name="pathExpression">Path expression.</param>
        /// <param name="defaultValue">Default value if the value doesn't exist.</param>
        /// <returns>Value or null if path is not valid.</returns>
        public int GetIntValue(string pathExpression, int defaultValue = 0)
        {
            if (TryGetValue<int>(pathExpression ?? throw new ArgumentNullException(nameof(pathExpression)), out var value))
            {
                return value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Get a bool value from memory using a path expression.
        /// </summary>
        /// <param name="pathExpression">The path expression.</param>
        /// <param name="defaultValue">Default value if the value doesn't exist.</param>
        /// <returns>Bool or null if path is not valid.</returns>
        public bool GetBoolValue(string pathExpression, bool defaultValue = false)
        {
            if (TryGetValue<bool>(pathExpression ?? throw new ArgumentNullException(nameof(pathExpression)), out var value))
            {
                return value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Get a string value from memory using a path expression.
        /// </summary>
        /// <param name="pathExpression">The path expression.</param>
        /// <param name="defaultValue">Default value if the value doesn't exist.</param>
        /// <returns>string or null if path is not valid.</returns>
        public string GetStringValue(string pathExpression, string defaultValue = default)
        {
            return GetValue(pathExpression, () => defaultValue);
        }

        /// <summary>
        /// Set memory to value.
        /// </summary>
        /// <param name="path">Path to memory.</param>
        /// <param name="value">Object to set.</param>
        public void SetValue(string path, object value)
        {
            if (value is Task)
            {
                throw new Exception($"{path} = You can't pass an unresolved Task to SetValue");
            }

            if (value != null)
            {
                value = JToken.FromObject(value);
            }

            path = TransformPath(path ?? throw new ArgumentNullException(nameof(path)));
            if (TrackChange(path, value))
            {
                ObjectPath.SetPathValue(this, path, value);
            }

            // Every set will increase version
            _version++;
        }

        /// <summary>
        /// Remove property from memory.
        /// </summary>
        /// <param name="path">Path to remove the leaf property.</param>
        public void RemoveValue(string path)
        {
            path = TransformPath(path ?? throw new ArgumentNullException(nameof(path)));
            if (TrackChange(path, null))
            {
                ObjectPath.RemovePathValue(this, path);
            }
        }

        /// <summary>
        /// Gets all memoryscopes suitable for logging.
        /// </summary>
        /// <returns>object which represents all memory scopes.</returns>
        public JObject GetMemorySnapshot()
        {
            var result = new JObject();

            foreach (var scope in Configuration.MemoryScopes.Where(ms => ms.IncludeInSnapshot))
            {
                var memory = scope.GetMemory(_dialogContext);
                if (memory != null)
                {
                    result[scope.Name] = JToken.FromObject(memory);
                }
            }

            return result;
        }

        /// <summary>
        /// Load all of the scopes.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        public async Task LoadAllScopesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var scope in Configuration.MemoryScopes)
            {
                await scope.LoadAsync(_dialogContext, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Save all changes for all scopes.
        /// </summary>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        public async Task SaveAllChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var scope in Configuration.MemoryScopes)
            {
                await scope.SaveChangesAsync(_dialogContext, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Delete the memory for a scope.
        /// </summary>
        /// <param name="name">name of the scope.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>Task.</returns>
        public async Task DeleteScopesMemoryAsync(string name, CancellationToken cancellationToken = default)
        {
            name = name.ToUpperInvariant();
            var scope = Configuration.MemoryScopes.SingleOrDefault(s => s.Name.ToUpperInvariant() == name);
            if (scope != null)
            {
                await scope.DeleteAsync(_dialogContext, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Adds a key value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, object value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks if the key is contained in any of the Configuration's Memory Scopes contains. 
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>A bool.</returns>
        public bool ContainsKey(string key)
        {
            return Configuration.MemoryScopes.Any(ms => ms.Name.ToUpperInvariant() == key.ToUpperInvariant());
        }

        /// <summary>
        /// Removes the key from the collection.
        /// </summary>
        /// <param name="key">The string to be removed.</param>
        /// <returns>A bool.</returns>
        public bool Remove(string key)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Attemps to retrieve a value, given a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>A bool.</returns>
        public bool TryGetValue(string key, out object value)
        {
            return TryGetValue<object>(key, out value);
        }

        /// <summary>
        /// Adds a key/value pair.
        /// </summary>
        /// <param name="item">The key-value pair you want to add.</param>
        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Resets the dictionary.
        /// </summary>
        public void Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks to see if the key value pair are contained in the collection.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey, TValue}"/>.</param>
        /// <returns>A bool.</returns>
        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Copies object at the parameter index to the next slot.
        /// </summary>
        /// <param name="array">The list of objects.</param>
        /// <param name="arrayIndex">The index.</param>
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            foreach (var ms in Configuration.MemoryScopes)
            {
                array[arrayIndex++] = new KeyValuePair<string, object>(ms.Name, ms.GetMemory(_dialogContext));
            }
        }

        /// <summary>
        /// Removes the key-value pair.
        /// </summary>
        /// <param name="item">The key-value pair you want to remove.</param>
        /// <returns>A bool.</returns>
        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets an enumerator for each memory scope in the configuration.
        /// </summary>
        /// <returns>A <see cref="KeyValuePair{TKey, TValue}"/>.</returns>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            foreach (var ms in Configuration.MemoryScopes)
            {
                yield return new KeyValuePair<string, object>(ms.Name, ms.GetMemory(_dialogContext));
            }
        }

        /// <summary>
        /// Track when specific paths are changed.
        /// </summary>
        /// <param name="paths">Paths to track.</param>
        /// <returns>Normalized paths to pass to <see cref="AnyPathChanged"/>.</returns>
        public List<string> TrackPaths(IEnumerable<string> paths)
        {
            var allPaths = new List<string>();
            foreach (var path in paths)
            {
                var tpath = TransformPath(path);

                // Track any path that resolves to a constant path
                if (ObjectPath.TryResolvePath(this, tpath, out var segments))
                {
                    var npath = string.Join("_", segments);
                    SetValue(PathTracker + "." + npath, 0);
                    allPaths.Add(npath);
                }
            }

            return allPaths;
        }

        /// <summary>
        /// Check to see if any path has changed since watermark.
        /// </summary>
        /// <param name="counter">Time counter to compare to.</param>
        /// <param name="paths">Paths from <see cref="TrackPaths"/> to check.</param>
        /// <returns>True if any path has changed since counter.</returns>
        public bool AnyPathChanged(uint counter, IEnumerable<string> paths)
        {
            var found = false;
            if (paths != null)
            {
                foreach (var path in paths)
                {
                    if (GetValue<uint>(PathTracker + "." + path) > counter)
                    {
                        found = true;
                        break;
                    }
                }
            }

            return found;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var ms in Configuration.MemoryScopes)
            {
                yield return new KeyValuePair<string, object>(ms.Name, ms.GetMemory(_dialogContext));
            }
        }

        private static bool TryGetFirstNestedValue<T>(ref T value, ref string remainingPath, object memory)
        {
            if (ObjectPath.TryGetPathValue<JArray>(memory, remainingPath, out var array))
            {
                if (array != null && array.Count > 0)
                {
                    if (array[0] is JArray first)
                    {
                        if (first.Count > 0)
                        {
                            var second = first[0];
                            value = ObjectPath.MapValueTo<T>(second);
                            return true;
                        }

                        return false;
                    }

                    value = ObjectPath.MapValueTo<T>(array[0]);
                    return true;
                }
            }

            return false;
        }

        private string GetBadScopeMessage(string path)
        {
            return $"'{path}' does not match memory scopes:[{string.Join(",", Configuration.MemoryScopes.Select(ms => ms.Name))}]";
        }

        private bool TrackChange(string path, object value)
        {
            var hasPath = false;
            if (ObjectPath.TryResolvePath(this, path, out var segments))
            {
                var root = segments.Count > 1 ? segments[1] as string : string.Empty;

                // Skip _* as first scope, i.e. _adaptive, _tracker, ...
                if (!root.StartsWith("_", StringComparison.Ordinal))
                {
                    // Convert to a simple path with _ between segments
                    var pathName = string.Join("_", segments);
                    var trackedPath = $"{PathTracker}.{pathName}";
                    uint? counter = null;

                    void Update()
                    {
                        if (TryGetValue<uint>(trackedPath, out var lastChanged))
                        {
                            if (!counter.HasValue)
                            {
                                counter = GetValue<uint>(DialogPath.EventCounter);
                            }

                            SetValue(trackedPath, counter.Value);
                        }
                    }

                    Update();
                    if (value is object obj)
                    {
                        // For an object we need to see if any children path are being tracked
                        void CheckChildren(string property, object instance)
                        {
                            // Add new child segment
                            trackedPath += "_" + property.ToLowerInvariant();
                            Update();
                            if (instance is object child)
                            {
                                ObjectPath.ForEachProperty(child, CheckChildren);
                            }

                            // Remove added child segment
                            trackedPath = trackedPath.Substring(0, trackedPath.LastIndexOf('_'));
                        }

                        ObjectPath.ForEachProperty(obj, CheckChildren);
                    }
                }

                hasPath = true;
            }

            return hasPath;
        }
    }
}
