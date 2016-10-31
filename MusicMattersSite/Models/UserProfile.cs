using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicMattersSite.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("AppUser")]
        public string UserID { get; set; }
        public string Bio { get; set; }
        [Required]
        public byte ShowEmail { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
    }
}