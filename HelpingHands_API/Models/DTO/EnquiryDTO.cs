using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class EnquiryDTO
    {
        public int Id { get; set; }

        public int CompanyID { get; set; }
        [ValidateNever]
        public CompanyDTO Company { get; set; }


        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUserDTO ApplicationUser { get; set; }


        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("User Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("User Phone Number")]
        public int PhoneNumber { get; set; }
        [Required]
        [DisplayName("Enquiry Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Brif Description Of Your Enquiry")]
        public string Description { get; set; }
    }
}
