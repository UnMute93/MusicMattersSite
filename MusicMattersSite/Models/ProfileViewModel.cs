using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class ProfileViewModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string BackgroundColor { get; set; }
        public byte ShowEmail { get; set; }
        public List<ArtistRanking> Artists { get; set; }
        public List<ProfileComment> Comments { get; set; }
        public List<Flag> Flags { get; set; }

        public Comment Comment { get; set; }
        public Flag Flag { get; set; }
    }

    public class ArtistRanking
    {
        public int ArtistID;
        public string ArtistName;
        public int Ranking;
    }

    public class ProfileComment
    {
        public int CommentID { get; set; }
        public string AuthorID { get; set; }
        public string AuthorName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string SortKey { get; set; }
        public int ParentID { get; set; }
        public DateTime TimeCreated { get; set; }
        public Nullable<DateTime> TimeEdited { get; set; }
    }
}