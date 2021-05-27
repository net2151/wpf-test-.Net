// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Windows;
using System.Windows.Documents;

namespace Microsoft.Test.Layout {
    internal class ColumnResultW: ReflectionHelper {
        public ColumnResultW(object columnResult):
            base(columnResult, "MS.Internal.Documents.ColumnResult")
        {
        }
        
        public TextPointer StartPosition { 
            get { return (TextPointer)GetProperty("StartPosition"); } 
        }          
        
        public TextPointer EndPosition { 
            get { return (TextPointer)GetProperty("EndPosition"); } 
        }
        
        public Rect LayoutBox { 
            get { return (Rect)GetProperty("LayoutBox"); }
        }
        
        public ParagraphResultListW Paragraphs {
            get { 
                return new ParagraphResultListW((IEnumerable)GetProperty("Paragraphs"));
            }
        }
    }
}
