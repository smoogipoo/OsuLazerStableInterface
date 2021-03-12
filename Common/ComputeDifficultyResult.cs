// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Generic;

namespace Common
{
    public class ComputeDifficultyResult
    {
        public double Stars { get; set; }
        public Dictionary<int, string> Attributes { get; set; }
    }
}
