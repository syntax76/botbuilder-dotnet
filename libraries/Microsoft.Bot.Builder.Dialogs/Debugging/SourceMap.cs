﻿// Licensed under the MIT License.
// Copyright (c) Microsoft Corporation. All rights reserved.

using System.Collections.Generic;

namespace Microsoft.Bot.Builder.Dialogs.Debugging
{
        /// <summary>
        /// A simple ISourceMap of objects -> SourceRange.
        /// </summary>
        public class SourceMap : Dictionary<object, SourceRange>, ISourceMap
        {
            /// <summary>
            /// A readonly instance of <see cref="SourceMap"/>.
            /// </summary>
            public static readonly SourceMap Instance = new SourceMap();
        }
}
