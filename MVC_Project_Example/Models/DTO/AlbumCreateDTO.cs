using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project_Example.Models.DTO
{
    public class AlbumCreateDTO
    {
        [Required(ErrorMessage = "Please type into artist name")]
        public string Name { get; set; }

        [RegularExpression(@"[1-500]+$", ErrorMessage = "Only numbers are allowed")]
        public int TotalTrack { get; set; }

        [RegularExpression(@"[1-500]+$", ErrorMessage = "Only numbers are allowed")]
        public int ArtistId { get; set; }
    }
}