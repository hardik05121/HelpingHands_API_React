using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class ReviewXCommentCreateDTO
    {

        public int Id { get; set; }

        public int CompanyID { get; set; }

        public int ReviewID { get; set; }


        public string ApplicationUserId { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DisplayName("Replay Comment")]
        public string Comment { get; set; }

    }
}
