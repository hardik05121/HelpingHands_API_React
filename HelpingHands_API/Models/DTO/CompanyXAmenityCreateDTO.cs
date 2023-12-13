using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class CompanyXAmenityCreateDTO   
    {
        
        public int Id { get; set; }
        public int AmenityId { get; set; }
        public int CompanyId{ get; set; }        
    }
}
