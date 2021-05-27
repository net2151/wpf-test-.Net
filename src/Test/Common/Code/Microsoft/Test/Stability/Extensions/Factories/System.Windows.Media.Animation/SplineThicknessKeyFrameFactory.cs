// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Media.Animation;
using Microsoft.Test.Stability.Core;

namespace Microsoft.Test.Stability.Extensions.Factories
{
    internal class SplineThicknessKeyFrameFactory : ThicknessKeyFrameFactory<SplineThicknessKeyFrame>
    {
        public KeySpline KeySpline { get; set; }

        public override SplineThicknessKeyFrame Create(DeterministicRandom random)
        {
            SplineThicknessKeyFrame splineThicknessKeyFrame = new SplineThicknessKeyFrame();
            splineThicknessKeyFrame.KeySpline = KeySpline;
            ApplyThicknessKeyFrameProperties(splineThicknessKeyFrame, random);

            return splineThicknessKeyFrame;
        }
    }
}
