using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class ServiceUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Service Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The field must be between 3 and 15 characters.")]
        public string ServiceName { get; set; }
		[DisplayName("first category")]
		[Required]
		public int FirstCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
