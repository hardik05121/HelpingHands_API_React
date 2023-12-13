
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class ServiceUpdateVM
    {
        public ServiceUpdateVM()
        {
            Service = new ServiceUpdateDTO();
        }
        public ServiceUpdateDTO Service { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }

    }
}
