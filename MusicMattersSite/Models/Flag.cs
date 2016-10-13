using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class Flag
    {
        public int FlagID { get; set; }
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Flaggable> Flaggable { get; set; }
    }
}