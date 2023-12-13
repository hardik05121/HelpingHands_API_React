using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class CompanyXServiceDTO
    {
        [Required]
        public int Id { get; set; }

        public int CompanyId { get; set; }
        [ValidateNever]
        public CompanyDTO Company { get; set; }

        public int ServiceId{ get; set; }
        [ValidateNever]
        public ServiceDTO Service { get; set; }


    }
}
