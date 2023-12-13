﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_API.Models.DTO
{
    public class ThirdCategoryDTO
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Third Category")]
        public string ThirdCategoryName { get; set; }
        [DisplayName("Third Category Image")]
        public string ThirdCategoryImage { get; set; }


        public int FirstCategoryId { get; set; }
        [ValidateNever]
        public FirstCategoryDTO FirstCategory { get; set; }

        public int SecondCategoryId { get; set; }
        [ValidateNever]
        public SecondCategoryDTO SecondCategory { get; set; }

        public bool IsActive { get; set; }


    }
}