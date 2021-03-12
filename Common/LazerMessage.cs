// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using Newtonsoft.Json;

namespace Common
{
    public class LazerMessage
    {
        [JsonProperty]
        public string Target { get; private set; }

        [JsonProperty]
        public string[] Data { get; private set; }

        [JsonConstructor]
        private LazerMessage()
        {
        }

        public LazerMessage(string target, object[] args)
        {
            Target = target;
            Data = args.Select(JsonConvert.SerializeObject).ToArray();
        }

        public object GetArg(int index, Type type) => JsonConvert.DeserializeObject(Data[index], type);
    }
}
