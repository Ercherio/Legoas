using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Legoas.Models
{
    [Table("tb_tr_accountoffices")]
    public class AccountOffice
    {
        public string Email { get; set; }
        public int OfficeId { get; set; }

        //relation n cardinality
        [JsonIgnore]
        [ForeignKey(nameof(Email))]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(OfficeId))]
        public virtual Office? Office { get; set; }


    }
}
