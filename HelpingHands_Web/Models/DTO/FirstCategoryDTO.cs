using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpingHands_Web.Models.DTO
{
    public class FirstCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Category")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The field must be between 3 and 15 characters.")]
        public string FirstCategoryName { get; set; }
        [DisplayName("First CategoryImage")]
        public string FirstCategoryImage { get; set; }

        public bool IsActive { get; set; }


    }
}
