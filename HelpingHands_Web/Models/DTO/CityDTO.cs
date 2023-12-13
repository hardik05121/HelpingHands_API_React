using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class CityDTO
    {
        [Required] 
        public int Id { get; set; }

        [Required]
        [DisplayName("City Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The field must be between 3 and 15 characters.")]
        public string CityName { get; set; }

        public int CountryId { get; set; }
        [ValidateNever]
        public CountryDTO Country { get; set; }

        public int StateId { get; set; }
        [ValidateNever]
        public StateDTO State { get; set; }

        public bool IsActive { get; set; }


    }
}
