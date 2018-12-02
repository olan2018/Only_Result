using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class TutorItem
    {
        public int ID { get; set; }
        [Required]
        public UserItem User { get; set; }
        [Required]
        public string Profile { get; set; }
        public ICollection<StudentItem> Students { get; set; }
    }
}
