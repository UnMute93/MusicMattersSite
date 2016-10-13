using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class CommentHistory
    {
        public int ID { get; set; }
        public int CommentId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Action { get; set; }
        public System.DateTime Time { get; set; }
    }
}