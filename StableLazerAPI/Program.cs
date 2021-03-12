// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace StableLazerAPI
{
    public class Program
    {
        internal static void Main(string[] args)
        {
            var adapter = new LazerAdapter();

            var result = adapter.ComputeDifficulty("/home/smgi/Downloads/2021_01_01_osu_files/1423969.osu", 0, 0);

            Console.WriteLine($"Stars: {result.Stars}");
        }
    }
}
