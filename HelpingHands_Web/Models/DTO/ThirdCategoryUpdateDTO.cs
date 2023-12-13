using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class ThirdCategoryUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
		[DisplayName("third category")]
		[StringLength(15, MinimumLength = 3, ErrorMessage = "The field must be between 3 and 15 characters.")]
        public string ThirdCategoryName { get; set; }

        [DisplayName("Third Category Image")]
        public string ThirdCategoryImage { get; set; }
        [Required]
        [DisplayName("first category")]
		public int FirstCategoryId { get; set; }
        [Required]
        [DisplayName("second category")]
		public int SecondCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
