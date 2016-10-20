using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MusicMattersSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        //public virtual List<Comment> AuthoredComments { get; set; }
        //public virtual List<Comment> RecievedComments { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ApplicationUser> AppUser { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentHistory> CommentHistory { get; set; }
        public DbSet<Flag> Flag { get; set; }
        public DbSet<Flaggable> Flaggable { get; set; }
        public DbSet<UserArtist> UserArtist { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Comment>().MapToStoredProcedures(s => s.Insert(u => u.HasName("[dbo].[comment_insert_sortkey]")));
            //modelBuilder.Entity<ApplicationUser>().HasMany(u => u.AuthoredComments).WithRequired(u => u.UserAuthor).WillCascadeOnDelete(false);
            //modelBuilder.Entity<ApplicationUser>().HasMany(u => u.RecievedComments).WithRequired(u => u.UserRecipient).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Comment>().HasRequired(u => u.UserAuthor).WithMany(u => u.AuthoredComments).HasForeignKey(u => u.UserAuthorID).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Comment>().HasRequired(u => u.UserRecipient).WithMany(u => u.RecievedComments).HasForeignKey(u => u.UserRecipientID).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }*/

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}