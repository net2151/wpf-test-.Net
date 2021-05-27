// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Controls;
using System.Windows.Documents;

namespace Microsoft.Test.Stability.Extensions.Actions
{
    /// <summary>
    /// TextBlock add an Inline.
    /// </summary>
    public class TextBlockAddInlineAction : SimpleDiscoverableAction
    {
        #region Public Members

        [InputAttribute(ContentInputSource.GetFromLogicalTree)]
        public TextBlock Target { get; set; }

        public Inline Inline { get; set; }

        #endregion

        #region Override Members

        public override void Perform()
        {
            Target.Inlines.Add(Inline);
        }

        public override bool CanPerform()
        {
            return (Inline.GetType() != typeof(Figure) && Inline.GetType() != typeof(Floater));
        }

        #endregion
    }
}
