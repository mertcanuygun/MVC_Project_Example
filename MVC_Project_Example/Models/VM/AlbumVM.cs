using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project_Example.Models.VM
{
    public class AlbumVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalTrack { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public int Status { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

    }
}