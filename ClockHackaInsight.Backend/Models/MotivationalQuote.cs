﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockHackaInsight.Backend.Models
{
    public class MotivationalQuote
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Quote { get; set; }

    }
}
