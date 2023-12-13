
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class SecondCategoryDeleteVM
    {
        public SecondCategoryDeleteVM()
        {
            SecondCategory = new SecondCategoryDTO();
        }
        public SecondCategoryDTO SecondCategory { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }
    }
}
