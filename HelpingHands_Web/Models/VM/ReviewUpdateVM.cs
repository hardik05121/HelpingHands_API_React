
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class ReviewUpdateVM
    {
        public ReviewUpdateVM()
        {
            Review = new ReviewUpdateDTO();
        }
        public ReviewUpdateDTO Review { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CompanyList { get; set; }

    }
}
