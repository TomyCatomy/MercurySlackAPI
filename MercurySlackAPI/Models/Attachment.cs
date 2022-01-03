using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Attachment
    {
        public string color { get; set; }
        public List<Block> blocks { get; set; }
        public List<AttachmentField> fields { get; set; }
    }
}
