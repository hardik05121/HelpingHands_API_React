using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class CompanyImageDTO
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Company Image")]
        public string Image { get; set; }
        public int CompanyId { get; set; }
        [ValidateNever]
        public CompanyDTO Company { get; set; }
        public bool IsActive { get; set; }
    }
}
