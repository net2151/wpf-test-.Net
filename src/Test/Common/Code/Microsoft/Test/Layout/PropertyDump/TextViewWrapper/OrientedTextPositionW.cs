// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Reflection;
using System.Windows.Documents;

namespace Microsoft.Test.Layout {
    internal class OrientedTextPositionW: ReflectionHelper {
        public OrientedTextPositionW(object orientedTextPosition):
            base(orientedTextPosition, "MS.Internal.Documents.OrientedTextPosition")
        {
        }
        
        public TextPointer TextPointer{ 
            get { return (TextPointer)GetProperty("TextPointer"); }
        }
        
        public LogicalDirection Orientation { 
            get { return (LogicalDirection)GetProperty("Orientation"); }
        }     
    }   
}
