//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Project_Example
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Song()
        {
            this.PlayList_Song = new HashSet<PlayList_Song>();
        }
    
        public int Id { get; set; }
        public string SongName { get; set; }
        public double Length { get; set; }
        public int TrackNo { get; set; }
        public string SongWriter { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public int Status { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayList_Song> PlayList_Song { get; set; }
    }
}
