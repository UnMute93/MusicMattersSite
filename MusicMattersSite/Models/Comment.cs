using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string UserAuthorID { get; set; }
        public string UserRecipientID { get; set; }
        public int ParentID { get; set; }
        public string SortKey { get; set; }
        [Required]
        public string Content { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeEdited { get; set; }
        
        [ForeignKey("UserAuthorID"), Column(Order = 0)]
        public virtual ApplicationUser UserAuthor { get; set; }
        [ForeignKey("UserRecipientID"), Column(Order = 1)]
        public virtual ApplicationUser UserRecipient { get; set; }
    }
}