// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

// using System;
using System.Diagnostics;
using Common;
using Newtonsoft.Json;

namespace StableLazerAPI
{
    public class LazerAdapter : ILazer
    {
        public ComputeDifficultyResult ComputeDifficulty(string beatmapPath, int rulesetId, int mods)
            => post<ComputeDifficultyResult>(nameof(ComputeDifficulty), beatmapPath, rulesetId, mods);

        private TRes post<TRes>(string target, params object[] args)
        {
            // var json = JsonConvert.SerializeObject(new LazerMessage(target, args));
            // json = json.Replace("\\", "\\\\");
            // json = json.Replace("\"", "\\\"");
            // json = $"{json}";

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "LazerRunner.exe",
                    // Arguments = json,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            proc.StandardInput.WriteLine(JsonConvert.SerializeObject(new LazerMessage(target, args)));
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            return JsonConvert.DeserializeObject<TRes>(output);
        }
    }
}
