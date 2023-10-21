using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Legoas.Models
{
    [Table("tb_m_offices")]
    public class Office
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //cardinality
        [JsonIgnore]
        public virtual ICollection<AccountOffice> AccountOffices { get; set; }

    }
}
