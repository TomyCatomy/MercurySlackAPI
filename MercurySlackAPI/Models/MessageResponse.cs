using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    public class MessageResponse
    {
        public bool ok { get; set; }
        public string error { get; set; }
        public string channel { get; set; }
        public string ts { get; set; }
    }
}
