using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class SecondCategoryCreateDTO
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Second Category")]
        public string SecondCategoryName { get; set; }
        [DisplayName("Second Category Image")]
        public string SecondCategoryImage { get; set; }

        public int FirstCategoryId { get; set; }

        public bool IsActive { get; set; }


    }
}
