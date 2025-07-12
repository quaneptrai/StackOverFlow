using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StackOverFlow.Models
{
    public class User
    {
        [Key]
        public int UsernameId { get; set; }
        [Required, DisplayName("First Name")]
        public string Firstname  { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required, StringLength(60)]
        public string Email { get; set; }
        [StringLength(16,MinimumLength = 6)]
        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }
}
