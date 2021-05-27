// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

namespace Microsoft.Test.Stability.Extensions.Actions
{
    /// <summary>
    /// Vector3DAnimate DirectionalLight.DirectionProperty.
    /// </summary>
    public class Vector3DAnimateDirectionalLightAction : SimpleDiscoverableAction
    {
        #region Public Members

        /// <summary/>
        [InputAttribute(ContentInputSource.GetFromLogicalTree)]
        public Viewport3D Viewport3D { get; set; }

        /// <summary/>
        [InputAttribute(ContentInputSource.CreateFromFactory, IsEssentialContent=true)]
        public Vector3DAnimation Vector3DAnimation { get; set; }

        /// <summary/>
        public HandoffBehavior HandoffBehavior { get; set; }

        #endregion

        #region Override Members

        public override void Perform()
        {
            GetDirectionalLightFromViewport3D(Viewport3D).BeginAnimation(DirectionalLight.DirectionProperty, Vector3DAnimation, HandoffBehavior);
        }

        public override bool CanPerform()
        {
            return (GetDirectionalLightFromViewport3D(Viewport3D)!=null);
        }

        #endregion

        /// <summary>
        /// Get DirectionalLight from Viewport3D, since get from ObjectTree directly will takes too much time and resource
        /// Work around 

        private DirectionalLight GetDirectionalLightFromViewport3D(Viewport3D Viewport3D)
        {
            if (Viewport3D != null && Viewport3D.Children.Count != 0)
            {
                foreach (Visual3D visual3D in Viewport3D.Children)
                {
                    if (visual3D.GetType() == typeof(ModelVisual3D))
                    {
                        Model3D visualContent = ((ModelVisual3D)(visual3D)).Content;
                        if ((visualContent != null) && visualContent.GetType() == typeof(DirectionalLight))
                        {
                            return visualContent as DirectionalLight;
                        }
                    }

                    if (visual3D.GetType() == typeof(ModelUIElement3D))
                    {
                        Model3D visualModel = ((ModelUIElement3D)(visual3D)).Model;
                        if (visualModel != null && visualModel.GetType() == typeof(DirectionalLight))
                        {
                            return visualModel as DirectionalLight;
                        }
                    }
                }
            }

            return null;
        }
    }
}
