using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.BaseEntity
{
	public class BaseEntity
    {
        public int Id { get; set; }
        public string InsertedUser { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;

        public string? UpdatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string IsActive { get; set; }
    }
}
