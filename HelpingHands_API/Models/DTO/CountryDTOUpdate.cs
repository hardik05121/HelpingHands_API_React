using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelpingHands_API.Models.DTO
{
    public class CountryUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        public bool IsActive { get; set; }


    }
}
