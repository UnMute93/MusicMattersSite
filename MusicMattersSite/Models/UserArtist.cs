using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMattersSite.Models
{
    public class UserArtist
    {
        [Key, ForeignKey("AppUser")]
        public int UserID { get; set; }
        [Key, ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public Nullable<int> Ranking { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
    }
}