using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GetProfileResponse
    {
        public bool ok { get; set; }
        public Profile profile { get; set; }
    }
}
