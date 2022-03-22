using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project_Example.Models.VM
{
    public class AlbumDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalTrack { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public int Status { get; set; }
    }
}