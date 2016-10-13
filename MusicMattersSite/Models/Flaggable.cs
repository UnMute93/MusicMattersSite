using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class Flaggable
    {
        [Key]
        public int ID { get; set; }
        public int FlagID { get; set; }
        [Required]
        public string FlaggableType { get; set; }
        public int FlaggableID { get; set; }
        public System.DateTime Time { get; set; }

        public virtual Flag Flag { get; set; }
    }
}