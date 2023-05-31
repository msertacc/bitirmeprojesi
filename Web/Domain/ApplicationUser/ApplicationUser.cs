using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Domain.ApplicationUser
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(11)]
        public string? IdentityNumber { get; set; }

        [Required]
        [StringLength(2)]
        public string? Gender { get; set; }

        [Required]
        [StringLength(2)]
        public string? RoleId { get; set; }

        [Required]
        [StringLength(1)]
        public string? IsVerify { get; set; }

        public string InsertedUser { get; set; }

        public DateTime InsertedDate { get; set; }

        public string? UpdatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string IsActive { get; set; }
    }
}
