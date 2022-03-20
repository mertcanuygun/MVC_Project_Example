using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project_Example.Models.DTO
{
    public class ArtistUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please type into artist name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        [RegularExpression(@"[A-Za-z ]+$", ErrorMessage = "Only letters are allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please type into artist name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        [RegularExpression(@"[A-Za-z ]+$", ErrorMessage = "Only letters are allowed")]
        public string LastName { get; set; }

    }
}