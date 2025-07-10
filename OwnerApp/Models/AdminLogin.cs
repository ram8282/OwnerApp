using System.ComponentModel.DataAnnotations;

namespace OwnerApp.Models
{
    public class AdminLogin
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
