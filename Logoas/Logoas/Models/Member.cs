using Legoas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Logoas.Models
{
    [Table("tb_m_member")]
    public class Member
    {
        [Key, Column("member_nik", TypeName = "nchar(16)")]
        public string NIK { get; set; }
        [Required, Column("name"), MaxLength(255)]
        public string Name { get; set; }

        [Required, Column("phone number"), MaxLength(255)]
        public string PhoneNumber { get; set; }
        [Required, Column("address"), MaxLength(255)]
        public string Address { get; set; }
        [Required, Column("email"), MaxLength(255)]
        public string Email { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
    }
}
