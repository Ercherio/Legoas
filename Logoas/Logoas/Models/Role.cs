using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Legoas.Models
{
    [Table("tb_m_roles")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //cardinality
        [JsonIgnore]
        public virtual ICollection<AccountRole>? AccountRoles { get; set; }
    }
}
