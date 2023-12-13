
using HelpingHands_API.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_API.Models.VM
{
    public class CompanyXServiceCreateVM
	{
        public CompanyXServiceCreateVM()
        {
			CompanyXService = new CompanyXServiceCreateDTO();
        }
        public CompanyXServiceCreateDTO CompanyXService { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        [ValidateNever]
        public List<ServiceDTO> ServiceList{ get; set; }

	}
}
