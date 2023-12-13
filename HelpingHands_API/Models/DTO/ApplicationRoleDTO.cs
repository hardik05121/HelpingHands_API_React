using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HelpingHands_API.Models.DTO
{
    public class ApplicationRoleDTO : IdentityRole
    {
        public bool IsChecked { get; set; }
    }
}
