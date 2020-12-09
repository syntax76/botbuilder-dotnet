﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;

namespace Microsoft.Bot.Builder.Runtime.Plugins
{
    /// <summary>
    /// Provides an implementation of <see cref="IBotPluginLoadContext"/> used to retrieve available
    /// bot plugins from an assembly.
    /// </summary>
    internal class AssemblyBotPluginEnumerator : IBotPluginEnumerator
    {
        private readonly AssemblyLoadContext _loadContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyBotPluginEnumerator"/> class.
        /// </summary>
        /// <param name="loadContext">
        /// Context used to discover and load assemblies available to the application runtime.
        /// </param>
        public AssemblyBotPluginEnumerator(AssemblyLoadContext loadContext)
        {
            this._loadContext = loadContext ?? throw new ArgumentNullException(nameof(loadContext));
        }

        /// <summary>
        /// Get available bot plugins.
        /// </summary>
        /// <param name="pluginName">Bot plugin identifier used to retrieve applicable plugins.</param>
        /// <returns>A collection of available bot plugins for the specified plugin name.</returns>
        public IEnumerable<IBotPlugin> GetPlugins(string pluginName)
        {
            if (string.IsNullOrWhiteSpace(pluginName))
            {
                throw new ArgumentNullException(nameof(pluginName));
            }

            var assemblyName = new AssemblyName(pluginName);
            Assembly pluginAssembly = this._loadContext.LoadFromAssemblyName(assemblyName);

            foreach (Type type in pluginAssembly.GetTypes())
            {
                if (typeof(IBotPlugin).IsAssignableFrom(type) &&
                    Activator.CreateInstance(type) is IBotPlugin plugin)
                {
                    yield return plugin;
                }
            }
        }
    }
}
