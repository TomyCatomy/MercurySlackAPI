using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Block
    {
        [JsonProperty("type")]
        public string block_type { get; set; }
        public Text text { get; set; }
        public List<Element> elements { get; set; }
        public List<Text> fields { get; set; }
    }
}
