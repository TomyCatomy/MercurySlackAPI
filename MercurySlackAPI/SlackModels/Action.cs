using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Action
    {
        public string action_id { get; set; }
        public string block_id { get; set; }
        public Text text { get; set; }
        public string value { get; set; }
        public string style { get; set; }
        public string type { get; set; }
        public string action_ts { get; set; }
    }
}
