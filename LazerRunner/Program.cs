using System;
using Common;
using LazerRunner;
using Newtonsoft.Json;

new Runner().Process(JsonConvert.DeserializeObject<LazerMessage>(Console.ReadLine()));
