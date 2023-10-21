using Logoas.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Legoas.Models { 

    [Table("tb_m_accounts")]
    public class Account
    {
        [Key]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Member Member { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRoles { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountOffice> AccountOffices { get; set; }

    }
}
