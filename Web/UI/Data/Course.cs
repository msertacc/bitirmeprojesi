using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Data
{

    [Table("Course")]
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
