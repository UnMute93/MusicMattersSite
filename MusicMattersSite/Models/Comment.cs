using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMattersSite.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        [ForeignKey("Comment")]
        public Nullable<int> ParentID { get; set; }
        public System.DateTime TimeCreated { get; set; }
        public Nullable<System.DateTime> TimeEdited { get; set; }
        
        public virtual Comment ParentComment { get; set; }
        public virtual ApplicationUser AppUser { get; set; }
    }
}