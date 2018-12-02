using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class StudentItem
    {
        public int ID { get; set; }
        [Required]
        public UserItem User { get; set; }
        [Required]
        public string Country { get; set; }
        public ICollection<TutorItem> Tutors { get; set; }
    }
}
