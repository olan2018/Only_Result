using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class UserItem
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? Created { get; set; }
    }
}
