using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Client.Models
{
    public class AccountRole
    {
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
