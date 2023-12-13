using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class PaymentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Payment Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The field must be between 3 and 15 characters.")]
        public string PaymentName { get; set; }

        public bool IsActive { get; set; }


    }
}
