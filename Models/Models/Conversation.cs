using System;

namespace Models.Models
{
    public class Conversation
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}