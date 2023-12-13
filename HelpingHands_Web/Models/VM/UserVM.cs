using HelpingHands_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpingHands_Web.Models.VM
{
    public class UserVM
    {
        public UserVM()
        {
            ApplicationUser = new ApplicationUserDTO();

            ApplicationUserRole = new ApplicationUserRoleDTO();
        }

        public ApplicationUserDTO ApplicationUser { get; set; }
        public ApplicationUserRoleDTO ApplicationUserRole { get; set; }

        [ValidateNever]
        public List<ApplicationUserRoleDTO> ApplicationUserRoleList { get; set; } 

        [ValidateNever]
        public List<ApplicationRoleDTO> ApplicationRoleList { get; set; }
    }
}
