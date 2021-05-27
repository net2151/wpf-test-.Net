// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

﻿using System.Windows.Media.Animation;
using Microsoft.Test.Stability.Core;

namespace Microsoft.Test.Stability.Extensions.Factories
{
    internal abstract class DoubleKeyFrameFactory<DoubleKeyFrameType> : DiscoverableFactory<DoubleKeyFrameType> where DoubleKeyFrameType : DoubleKeyFrame
    {
        #region Public Members

        public double Value { get; set; }

        public KeyTime KeyTime { get; set; }

        #endregion

        protected void ApplyDoubleKeyFrameProperties(DoubleKeyFrame doubleKeyFrame, DeterministicRandom random)
        {
            doubleKeyFrame.Value = Value;
            doubleKeyFrame.KeyTime = KeyTime;
        }
    }
}
