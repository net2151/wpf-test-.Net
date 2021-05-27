// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Media.Media3D;

namespace Microsoft.Test.Stability.Extensions.Actions
{
    /// <summary>
    /// Viewport3DVisual add a Visual3D.
    /// </summary>
    public class Viewport3DVisualAddVisual3DAction : SimpleDiscoverableAction
    {
        #region Public Members

        [InputAttribute(ContentInputSource.CreateFromFactory, IsEssentialContent = true)]
        public Visual3D Visual3D { get; set; }

        [InputAttribute(ContentInputSource.GetFromVisualTree)]
        public Viewport3DVisual Viewport3DVisual { get; set; }

        #endregion

        #region Override Members

        public override void Perform()
        {
            Viewport3DVisual.Children.Add(Visual3D);
        }

        #endregion
    }
}
