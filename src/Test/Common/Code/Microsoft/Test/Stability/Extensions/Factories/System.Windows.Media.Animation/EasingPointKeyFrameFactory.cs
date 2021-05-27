// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Media.Animation;
using Microsoft.Test.Stability.Core;

namespace Microsoft.Test.Stability.Extensions.Factories
{
    internal class EasingPointKeyFrameFactory : PointKeyFrameFactory<EasingPointKeyFrame>
    {
        public EasingFunctionBase EasingFunction { get; set; }

        public override EasingPointKeyFrame Create(DeterministicRandom random)
        {
            EasingPointKeyFrame easingPointKeyFrame = new EasingPointKeyFrame();
            easingPointKeyFrame.EasingFunction = EasingFunction;
            ApplyPointKeyFrameProperties(easingPointKeyFrame, random);

            return easingPointKeyFrame;
        }
    }
}
