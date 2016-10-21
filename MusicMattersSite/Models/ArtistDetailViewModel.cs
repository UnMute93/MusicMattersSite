using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMattersSite.Models
{
    public class ArtistDetailViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ActiveFrom { get; set; }
        public Nullable<DateTime> ActiveUntil { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
    }
}