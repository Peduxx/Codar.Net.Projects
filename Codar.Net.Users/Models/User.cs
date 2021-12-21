using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codar.Net.Users.Models.Base;
using Codar.Net.Users.Models.Enums;

namespace Codar.Net.Users.Models
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProfilePhoto { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int Attempts { get; set; }
        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }

        public static User Create(string name, string email, string password, int age)
        {
            return new User
            {
                Name = name,
                Email = email,
                Password = password,
                Age = age,
                Role = UserRole.FreeUser
            };
        }
    }
}