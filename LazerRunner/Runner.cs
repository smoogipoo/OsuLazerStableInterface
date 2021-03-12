// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Diagnostics;
using System.Linq;
using Common;
using Newtonsoft.Json;
using osu.Game.Beatmaps.Legacy;

namespace LazerRunner
{
    public class Runner : ILazer
    {
        public ComputeDifficultyResult ComputeDifficulty(string beatmapPath, int rulesetId, int mods)
        {
            var working = new CustomWorkingBeatmap(beatmapPath);

            var targetRuleset = LegacyHelper.GetRulesetFromLegacyID(rulesetId);
            var targetMods = targetRuleset.ConvertFromLegacyMods((LegacyMods)mods).ToArray();

            var attributes = targetRuleset.CreateDifficultyCalculator(working).Calculate(targetMods);

            return new ComputeDifficultyResult { Stars = attributes.StarRating };
        }

        public void Process(LazerMessage message)
        {
            var method = typeof(ILazer).GetMethod(message.Target);
            Debug.Assert(method != null);

            object[] typedArgs = method.GetParameters().Select((param, index) => message.GetArg(index, param.ParameterType)).ToArray();
            var result = method.Invoke(this, typedArgs);

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}
