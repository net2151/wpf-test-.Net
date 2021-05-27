// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Linq;
using System.Windows.Documents;

namespace Microsoft.Test.Stability.Extensions.Actions
{
    /// <summary>
    /// Remove a ListItem from List.
    /// </summary>
    public class ListRemoveListItemAction : SimpleDiscoverableAction
    {
        #region Public Members

        [InputAttribute(ContentInputSource.GetFromLogicalTree)]
        public List Target { get; set; }

        public int RemoveIndex { get; set; }

        #endregion

        #region Override Members

        public override bool CanPerform()
        {
            return Target.ListItems.Count > 0;
        }

        public override void Perform()
        {
            RemoveIndex %= Target.ListItems.Count;
            ListItem item = Target.ListItems.ElementAtOrDefault<ListItem>(RemoveIndex);
            Target.ListItems.Remove(item);
        }

        #endregion
    }
}
