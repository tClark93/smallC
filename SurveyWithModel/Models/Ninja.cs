using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SurveyWithModel.Models
{
    public class Ninja
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name {get;set;}
        
        [Required]
        [MinLength(3)]
        public string Location {get;set;}
        
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Language {get;set;}
        
        [MinLength(8)]
        [MaxLength(30)]
        public string Comment {get;set;}
    }
}