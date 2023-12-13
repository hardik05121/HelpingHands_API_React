using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class ServiceCreateDTO
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Service Name")]
        public string ServiceName { get; set; }

        public int FirstCategoryId { get; set; }


        public bool IsActive { get; set; }


    }
}
