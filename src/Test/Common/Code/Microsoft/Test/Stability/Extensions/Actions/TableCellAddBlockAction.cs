// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Documents;

namespace Microsoft.Test.Stability.Extensions.Actions
{
    /// <summary>
    /// TableCell Add a Block .
    /// </summary>
    public class TableCellAddBlockAction : SimpleDiscoverableAction
    {
        #region Public Members

        [InputAttribute(ContentInputSource.GetFromLogicalTree)]
        public TableCell Target { get; set; }

        public Block Block { get; set; }

        #endregion

        #region Override Members

        public override void Perform()
        {
            Target.Blocks.Add(Block);
        }

        #endregion
    }
}
