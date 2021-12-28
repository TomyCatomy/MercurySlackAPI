using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Container
    {
        public string type { get; set; }
        public string message_ts { get; set; }
        public string channel_id { get; set; }
        public bool is_ephemeral { get; set; }
    }
}
