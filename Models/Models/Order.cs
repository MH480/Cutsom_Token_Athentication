using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public OrderProgressLevelEnum ProgressLevel { get; set; }
        
        public virtual ICollection<Conversation> Conversations { get; set; }
    }
}