namespace MusicMattersSite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicMattersSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicMattersSite.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user1 = new ApplicationUser();
            user1.UserName = "UnMute";
            user1.Email = "misteranderson93@gmail.com";

            var user2 = new ApplicationUser();
            user2.UserName = "Troll";
            user2.Email = "troll@troll.com";
            manager.Create(user1, "Kappa123!");
            manager.Create(user2, "Keepo123!");

            

            context.UserProfile.AddOrUpdate(
                new UserProfile { UserID = "2e8b2696-e229-4dad-a9de-c0fe56359361", Bio = "This is some profile text.", ShowEmail = 1, BackgroundColor = "#FFFFFF" }
            );

            context.Comment.AddOrUpdate(
                new Comment { CommentID = 2, UserRecipientID = "2e8b2696-e229-4dad-a9de-c0fe56359361", UserAuthorID = "2e8b2696-e229-4dad-a9de-c0fe56359361", TimeCreated = new DateTime(2016, 10, 17, 14, 20, 0), Content = "This is a comment from myself to myself" },
                new Comment { CommentID = 1, UserRecipientID = "2e8b2696-e229-4dad-a9de-c0fe56359361", UserAuthorID = "176ce051-1214-4fc6-a5e6-a57591a4b262", TimeCreated = new DateTime(2016, 10, 17, 16, 18, 0), Content = "*Offensive stuff*" }
            );

            context.Artist.AddOrUpdate(
                new Artist { ArtistID = 4, Name = "Radiohead", Image = "~/Images/Artists/Radiohead/radiohead.jpg", Description = "Radiohead are an English rock band from Abingdon, Oxfordshire, formed in 1985. The band consists of Thom Yorke (lead vocals, guitar, piano, keyboards), Jonny Greenwood (lead guitar, keyboards, other instruments), Ed O'Brien (guitar, backing vocals), Colin Greenwood (bass), and Phil Selway (drums, percussion, backing vocals). They have worked with producer Nigel Godrich and cover artist Stanley Donwood since 1994.", IsAdminApproved = 1, ActiveFrom = new DateTime(1985, 1, 1) }
            );

            context.UserArtist.AddOrUpdate(
                new UserArtist { UserID = "2e8b2696-e229-4dad-a9de-c0fe56359361", ArtistID = 4, IsRanked = true, Ranking = 1 }
            );

            context.Flag.AddOrUpdate(
                new Flag { FlagID = 7, Name = "Offensive Content" },
                new Flag { FlagID = 8, Name = "Flaming" }
            );
        }
    }
}
