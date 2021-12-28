using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string team_id { get; set; }
    }
}
