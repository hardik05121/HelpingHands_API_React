
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class ThirdCategoryCreateVM
    {
        public ThirdCategoryCreateVM()
        {
            ThirdCategory = new ThirdCategoryCreateDTO();
        }
        public ThirdCategoryCreateDTO ThirdCategory { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SecondCategoryList { get; set; }
    }
}
