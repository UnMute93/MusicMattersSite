using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public int AlbumID { get; set; }
        [Required]
        public string Name { get; set; }
        public Nullable<System.TimeSpan> Length { get; set; }
        public int Order { get; set; }
        public Nullable<byte> IsSingle { get; set; }
        public byte IsAdminApproved { get; set; }

        public virtual Album Album { get; set; }
    }
}