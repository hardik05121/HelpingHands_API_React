using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpingHands_Web.Models.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        [DisplayName("username")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("password")]
        public string Password { get; set; }
    }
}
