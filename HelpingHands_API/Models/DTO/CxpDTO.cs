using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class CxpDTO
    {
        public int CompanyId { get; set; }
        public List<string> SelectedPaymentIds { get; set; }
    }
}
