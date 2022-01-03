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
        public Text(string _text_type, string _text, bool _emoji = true)
        {
            text_type = _text_type;
            text = _text;
            emoji = _emoji;
        }

        public Text(string _text, bool mrkdwn = false, bool _emoji = true)
        {
            if (mrkdwn)
                text_type = "mrkdwn";
            else
                text_type = "plain_text";

            text = _text;
            emoji = _emoji;
        }

        public static Text CreateLink(string url, string message)
        {
            string markdownText = $"<{url}|{message}>";
            var text = new Text(markdownText, true);
            return text;
        }
    }
}
