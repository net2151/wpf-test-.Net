// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System;
using System.Windows.Media.Animation;
using Microsoft.Test.Stability.Core;

namespace Microsoft.Test.Stability.Extensions.Factories
{
    class LinearPointKeyFrameFactory : PointKeyFrameFactory<LinearPointKeyFrame>
    {
        public override LinearPointKeyFrame Create(DeterministicRandom random)
        {
            LinearPointKeyFrame linearPointKeyFrame = new LinearPointKeyFrame();
            ApplyPointKeyFrameProperties(linearPointKeyFrame, random);

            return linearPointKeyFrame;
        }
    }
}
