using System;
using System.Collections.Generic;
using System.Text;

namespace MercurySlackAPI.Models
{
    public class ConversationMembersResponse
    {
        public bool ok { get; set; }
        public List<string> members { get; set; }
        public PaginationMetadata response_metadata { get; set; }
    }
}
