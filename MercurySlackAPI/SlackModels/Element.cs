using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Element
    {
        [JsonProperty("type")]
        public string element_type { get; set; }
        public Text text { get; set; }
        public string style { get; set; }
        public string value { get; set; }
        public string action_id { get; set; }
        public Element()
        {

        }
        public Element(string _element_type, string _action_id, string _text, string _style, string _value)
        {
            element_type = _element_type;
            action_id = _action_id;
            text = new Text(_text);
            style = _style;
            value = _value;
        }
    }
}
