using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Message
    {
        public string channel { get; set; }
        public string text { get; set; }
        public bool as_user { get; set; }
        public string bot_id { get; set; }
        public string type { get; set; }
        public string user { get; set; }
        public string ts { get; set; }
        public string team { get; set; }
        public List<Block> blocks { get; set; }
        public List<Attachment> attachments { get; set; }
    }
}
