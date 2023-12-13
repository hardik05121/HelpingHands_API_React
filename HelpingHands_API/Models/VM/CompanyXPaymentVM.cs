
using HelpingHands_API.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_API.Models.VM
{
	public class CompanyXPaymentVM
	{
		public CompanyXPaymentVM()
		{
			CompanyXPayment = new CompanyXPaymentCreateDTO();
			Company = new CompanyCreateDTO();
		}
		public CompanyXPaymentCreateDTO CompanyXPayment { get; set; }

		public CompanyCreateDTO Company { get; set; }

		[ValidateNever]
		public List<CompanyXPaymentCreateDTO> CompanyXPaymentlist { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> CompanyList { get; set; }
		public int CompanyId { get; set; }
		[ValidateNever]
		public List<PaymentDTO> Paymentlist { get; set; }
	}
}
