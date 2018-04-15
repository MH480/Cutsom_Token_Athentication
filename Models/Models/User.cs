using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Models.Enums;

namespace Models.Models
{
    public class User : IdentityUser
    {
        
        public bool IsActivated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public UserAccessLevelEnum UserAccessLevel { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }

    }
}