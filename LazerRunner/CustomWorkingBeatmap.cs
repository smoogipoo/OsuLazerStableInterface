// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.IO;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics.Textures;
using osu.Game.Beatmaps;
using osu.Game.Beatmaps.Formats;
using osu.Game.IO;

namespace LazerRunner
{
    public class CustomWorkingBeatmap : WorkingBeatmap
    {
        private readonly Beatmap beatmap;

        public CustomWorkingBeatmap(string file, int? beatmapId = null)
            : this(readFromFile(file), beatmapId)
        {
        }

        private CustomWorkingBeatmap(Beatmap beatmap, int? beatmapId = null)
            : base(beatmap.BeatmapInfo, null)
        {
            this.beatmap = beatmap;

            beatmap.BeatmapInfo.Ruleset = LegacyHelper.GetRulesetFromLegacyID(beatmap.BeatmapInfo.RulesetID).RulesetInfo;

            if (beatmapId.HasValue)
                beatmap.BeatmapInfo.OnlineBeatmapID = beatmapId;
        }

        private static Beatmap readFromFile(string filename)
        {
            using (var stream = File.OpenRead(filename))
            using (var reader = new LineBufferedReader(stream))
                return Decoder.GetDecoder<Beatmap>(reader).Decode(reader);
        }

        protected override IBeatmap GetBeatmap() => beatmap;
        protected override Texture GetBackground() => null;
        protected override Track GetBeatmapTrack() => null;
    }
}
