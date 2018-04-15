using System;

namespace Models.Models
{
    public class Token
    {
        public int Id { get; set; } 
        public string Hash { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}