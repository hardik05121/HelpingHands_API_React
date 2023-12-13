
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class SecondCategoryCreateVM
    {
        public SecondCategoryCreateVM()
        {
            SecondCategory = new SecondCategoryCreateDTO();
            
        }
        public SecondCategoryCreateDTO SecondCategory { get; set; }

    


        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }
    }
}
