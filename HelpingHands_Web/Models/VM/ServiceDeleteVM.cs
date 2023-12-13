
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class ServiceDeleteVM
    {
        public ServiceDeleteVM()
        {
            Service = new ServiceDTO();
        }
        public ServiceDTO Service { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }

    }
}
