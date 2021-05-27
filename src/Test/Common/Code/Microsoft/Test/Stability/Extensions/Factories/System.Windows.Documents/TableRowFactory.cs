// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Collections.Generic;
using System.Windows.Documents;
using Microsoft.Test.Stability.Core;
using Microsoft.Test.Stability.Extensions.Constraints;

namespace Microsoft.Test.Stability.Extensions.Factories
{
    [TargetTypeAttribute(typeof(TextElement))]
    internal class TableRowFactory : TextElementFactory<TableRow>
    {
        #region Public Members

        public List<TableCell> Cells { get; set; }

        #endregion

        #region Override Members

        public override TableRow Create(DeterministicRandom random)
        {
            TableRow tableRow = new TableRow();

            ApplyTextElementFactory(tableRow, random);
            HomelessTestHelpers.Merge(tableRow.Cells, Cells);

            return tableRow;
        }

        #endregion
    }
}
