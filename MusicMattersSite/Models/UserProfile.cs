using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicMattersSite.Models
{
    public class UserProfile
    {
        [Key]
        public int UserID { get; set; }
        public string Bio { get; set; }
        public string BackgroundColor { get; set; }
        public byte ShowEmail { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
    }
}
}