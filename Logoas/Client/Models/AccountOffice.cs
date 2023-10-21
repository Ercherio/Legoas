using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class AccountOffice
    {
        public string Email { get; set; }
        public int OfficeId { get; set; }
    }
}
