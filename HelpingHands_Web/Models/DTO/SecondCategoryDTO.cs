using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class SecondCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Second Category")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The field must be between 3 and 15 characters.")]
        public string SecondCategoryName { get; set; }

        [DisplayName("Second Category Image")]
        public string SecondCategoryImage { get; set; }

        public int FirstCategoryId { get; set; }
        [ValidateNever]
        public FirstCategoryDTO FirstCategory { get; set; }

        public bool IsActive { get; set; }


    }
}
