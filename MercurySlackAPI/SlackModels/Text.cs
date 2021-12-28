using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Text
    {
        [JsonProperty("type")]
        public string text_type { get; set; }
        public string text { get; set; }
        [JsonIgnore()]
        public bool emoji { get; set; }
        public Text()
        {

        }
        public Text(string _text_type, string _text)
        {
            text_type = _text_type;
            text = _text;
            emoji = true;
        }

        public Text(string _text)
        {
            text_type = "plain_text";
            text = _text;
            emoji = true;
        }

    }
}
