using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class InteractionPayload
    {
        public string type { get; set; }
        public User user { get; set; }
        public string api_app_id { get; set; }
        public string token { get; set; }
        public Container container { get; set; }
        public string trigger_id { get; set; }
        public Team team { get; set; }
        public object enterprise { get; set; }
        public bool is_enterprise_install { get; set; }
        public Channel channel { get; set; }
        public Message message { get; set; }
        public State state { get; set; }
        public string response_url { get; set; }
        public List<Action> actions { get; set; }
    }
}
