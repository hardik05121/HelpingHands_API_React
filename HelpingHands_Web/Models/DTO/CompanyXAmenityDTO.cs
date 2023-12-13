﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HelpingHands_Web.Models.DTO
{
    public class CompanyXAmenityDTO   
    {
        [Required]
        public int Id { get; set; }
        public int AmenityId { get; set; }
        [ValidateNever]
        public AmenityDTO Amenity { get; set; }
        public int CompanyId{ get; set; }
        [ValidateNever]
        public CompanyDTO Company { get; set; }
        
    }
}
