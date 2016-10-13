using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ActiveFrom { get; set; }
        public Nullable<System.DateTime> ActiveUntil { get; set; }
        public byte IsAdminApproved { get; set; }
        
        public virtual ICollection<Album> Album { get; set; }
        public virtual ICollection<UserArtist> UserArtist { get; set; }
    }
}