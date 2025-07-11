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
        [Required]
        public int Email { get; set; }
        [Range(6, 16)]
        public string Password { get; set; }
    }
}
