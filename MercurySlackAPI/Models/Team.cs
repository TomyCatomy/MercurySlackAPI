using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Team
    {
        public string id { get; set; }
        public string domain { get; set; }
    }
}
