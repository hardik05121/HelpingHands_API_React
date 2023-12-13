using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class ReviewDTO
    {
        [Required]
        public int Id { get; set; }


        public int CompanyID { get; set; }
        [ValidateNever]
        public CompanyDTO Company { get; set; }

        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUserDTO ApplicationUser { get; set; }


        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }



        [DisplayName("Like Count")]
        public int? LikeCount { get; set; }


        [DisplayName("Dis Like Count")]
        public int? DisLikeCount { get; set; }

        [DisplayName("View Count")]
        public int? ViewCount { get; set; }

        [DisplayName("Rating")]
        public int Rating { get; set; }

        [Required]
        [DisplayName("Review Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Review in Description")]
        public string Description { get; set; }

        public bool IsActive { get; set; }


    }
}
