
using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class AmenityUpdateVM
    {
        public AmenityUpdateVM()
        {
            Amenity = new AmenityUpdateDTO();
        }
        public AmenityUpdateDTO Amenity { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FirstCategoryList { get; set; }

    }
}
