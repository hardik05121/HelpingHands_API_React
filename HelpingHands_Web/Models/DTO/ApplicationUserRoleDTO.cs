using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HelpingHands_Web.Models
{
    public class ApplicationUserRoleDTO :IdentityUserRole<string>
    {
        
    }

}
