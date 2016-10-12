using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMattersSite.Models
{
    public class CommentHistory
    {
        public int ID { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string Action { get; set; }
        public System.DateTime Time { get; set; }
    }
}