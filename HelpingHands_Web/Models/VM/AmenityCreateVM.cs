
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class AmenityCreateVM
    {
        public AmenityCreateVM()
        {
            Amenity = new AmenityCreateDTO();
        }
        public AmenityCreateDTO Amenity { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }

    }
}
