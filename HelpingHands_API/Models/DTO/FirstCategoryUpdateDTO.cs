using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpingHands_API.Models.DTO
{
    public class FirstCategoryUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Category")]
        public string FirstCategoryName { get; set; }
        [DisplayName("First Category Image")]
        public string FirstCategoryImage { get; set; }

        public bool IsActive { get; set; }


    }
}
