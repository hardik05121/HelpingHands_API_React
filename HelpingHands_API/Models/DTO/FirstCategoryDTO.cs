using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpingHands_API.Models.DTO
{
    public class FirstCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Category")]
        public string FirstCategoryName { get; set; }
        [DisplayName("First CategoryImage")]
        public string FirstCategoryImage { get; set; }

        public bool IsActive { get; set; }


    }
}
