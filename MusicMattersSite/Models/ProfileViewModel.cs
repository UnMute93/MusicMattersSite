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

    public class EditProfileSettingsViewModel
    {
        public string UserID { get; set; }
        [Display(Name = "Profile text")]
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
        [Display(Name = "Show your email address to other users")]
        public byte ShowEmail { get; set; }
        [Display(Name = "Artists you like")]
        public List<ArtistRanking> Artists { get; set; }
    }
}