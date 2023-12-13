using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class PaymentDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Payment Name")]
        public string PaymentName { get; set; }

        public bool IsActive { get; set; }


    }
}
