using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class CompanyXPaymentCreateDTO
    {

        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int PaymentId{ get; set; }

    }
}
