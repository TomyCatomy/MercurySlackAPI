using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Profile
    {
        public string avatar_hash { get; set; }
        public string status_text { get; set; }
        public string status_emoji { get; set; }
        public int status_expiration { get; set; }
        public string real_name { get; set; }
        public string display_name { get; set; }
        public string real_name_normalized { get; set; }
        public string display_name_normalized { get; set; }
        public string email { get; set; }
        public string image_original { get; set; }
        public string image_24 { get; set; }
        public string image_32 { get; set; }
        public string image_48 { get; set; }
        public string image_72 { get; set; }
        public string image_192 { get; set; }
        public string image_512 { get; set; }
        public string team { get; set; }
    }
}
