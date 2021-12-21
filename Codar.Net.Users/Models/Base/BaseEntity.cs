using System;

namespace Codar.Net.Users.Models.Base
{
    public class BaseEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        
        public DateTime? DeletionDate { get; set; }
    }
}