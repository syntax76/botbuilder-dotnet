﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Bot.Builder.Dialogs.Memory.Scopes
{
    /// <summary>
    /// DialogMemoryScope maps "class" -> dc.ActiveDialog Properties.
    /// </summary>
    public class ClassMemoryScope : MemoryScope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassMemoryScope"/> class.
        /// </summary>
        public ClassMemoryScope()
            : base(ScopePath.Class)
        {
            this.IncludeInSnapshot = false;
        }

        /// <summary>
        /// Gets the active dialog's memory.
        /// </summary>
        /// <param name="dc">The dialog context.</param>
        /// <returns>An object representing the dialog's memory.</returns>
        public override object GetMemory(DialogContext dc)
        {
            if (dc == null)
            {
                throw new ArgumentNullException(nameof(dc));
            }

            // if active dialog is a container dialog then "dialog" binds to it.
            if (dc.ActiveDialog != null)
            {
                var dialog = dc.FindDialog(dc.ActiveDialog.Id);
                if (dialog != null)
                {
                    return new ReadOnlyObject(dialog);
                }
            }

            return null;
        }

        /// <summary>
        /// When overridden sets the dialog context to have the associated memory.
        /// </summary>
        /// <param name="dc">The dialog context.</param>
        /// <param name="memory">The object that serves as the memory.</param>
        public override void SetMemory(DialogContext dc, object memory)
        {
            throw new NotSupportedException("You can't modify the class scope");
        }
    }
}
