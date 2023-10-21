using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Legoas.Models
{
    [Table("tb_tr_account_roles")]
    public class AccountRole
    {
        public string Email { get; set; }

        public int RoleId { get; set; }

        //relation n cardinality
        [JsonIgnore]
        [ForeignKey(nameof(Email))]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
    }
}
