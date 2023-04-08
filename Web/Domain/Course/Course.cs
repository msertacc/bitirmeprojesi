using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity.Domain.Course
{

    [Table("Course")]
    public class Course:BaseEntity.BaseEntity
    {
        [Required]
        public virtual string? Name { get; set; }

    }
}
