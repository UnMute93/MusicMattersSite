using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Image { get; set; }
        public byte IsAdminApproved { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}