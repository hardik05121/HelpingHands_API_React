using HelpingHands_API.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_API.Models.VM
{
    public class HomeVM
    {
        public HomeVM()
        {
            CompanyImage = new CompanyImageCreateDTO();
        }
        public CompanyImageCreateDTO CompanyImage { get; set; }

        public CompanyDTO Company { get; set; }



        [ValidateNever]
        public List<FirstCategoryDTO> FirstCategoryList { get; set; }

        [ValidateNever]
        public List<SecondCategoryDTO> SecondCategoryList { get; set; }

        [ValidateNever]
        public List<ThirdCategoryDTO> ThirdCategoryList { get; set; }

        [ValidateNever]
        public List<CompanyDTO> CompanyList { get; set; }
    }
}
