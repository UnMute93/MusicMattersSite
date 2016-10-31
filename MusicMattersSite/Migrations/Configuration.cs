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
                new UserProfile { UserID = "2e8b2696-e229-4dad-a9de-c0fe56359361", Bio = "This is some profile text.", ShowEmail = 1 },
                new UserProfile { UserID = "176ce051-1214-4fc6-a5e6-a57591a4b262", Bio = "Hi, I'm a troll.", ShowEmail = 0 }
            );

            context.Comment.AddOrUpdate(
                new Comment { CommentID = 2, UserRecipientID = "2e8b2696-e229-4dad-a9de-c0fe56359361", UserAuthorID = "2e8b2696-e229-4dad-a9de-c0fe56359361", TimeCreated = new DateTime(2016, 10, 17, 14, 20, 0), Content = "This is a comment from myself to myself", SortKey = "0002" },
                new Comment { CommentID = 1, UserRecipientID = "2e8b2696-e229-4dad-a9de-c0fe56359361", UserAuthorID = "176ce051-1214-4fc6-a5e6-a57591a4b262", TimeCreated = new DateTime(2016, 10, 17, 16, 18, 0), Content = "*Offensive stuff*", SortKey = "0001" }
            );

            context.Artist.AddOrUpdate(
                new Artist { ArtistID = 4, Name = "Radiohead", Image = "~/Images/Artists/Radiohead/radiohead.jpg", Description = "Radiohead are an English rock band from Abingdon, Oxfordshire, formed in 1985. The band consists of Thom Yorke (lead vocals, guitar, piano, keyboards), Jonny Greenwood (lead guitar, keyboards, other instruments), Ed O'Brien (guitar, backing vocals), Colin Greenwood (bass), and Phil Selway (drums, percussion, backing vocals). They have worked with producer Nigel Godrich and cover artist Stanley Donwood since 1994.", IsAdminApproved = 1, ActiveFrom = new DateTime(1985, 1, 1) },
                new Artist { ArtistID = 12, Name = "Caravan Palace", Image = "~/Images/Artists/Caravan Palace/caravan_palace.jpg", Description = "Caravan Palace is a French electro swing band based in Paris. The band's influences include Django Reinhardt, Vitalic, Lionel Hampton, and Daft Punk. The band released their debut studio album, Caravan Palace, on the Wagram label in October 2008. The record charted in Switzerland, Belgium and France, where it reached a peak position of number 11.", IsAdminApproved = 1, ActiveFrom = new DateTime(2008, 1, 1) }
            );

            context.Album.AddOrUpdate(
                new Album { AlbumID = 1, ArtistID = 4, Name = "OK Computer", Image = "~/Images/Artists/Radiohead/ok_computer_cover.jpg", ReleaseDate = new DateTime(1997, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 2, ArtistID = 4, Name = "Kid A", Image = "~/Images/Artists/Radiohead/kid_a_cover.jpg", ReleaseDate = new DateTime(2000, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 3, ArtistID = 4, Name = "In Rainbows", Image = "~/Images/Artists/Radiohead/in_rainbows_cover.jpg", ReleaseDate = new DateTime(2007, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 4, ArtistID = 12, Name = "Caravan Palace", Image = "~/Images/Artists/Caravan Palace/caravan_palace_cover.jpg", ReleaseDate = new DateTime(2008, 1, 1), IsAdminApproved = 1 }
            );

            context.Song.AddOrUpdate(
                new Song { SongID = 1, AlbumID = 1, Name = "Airbag", Order = 1, Length = new TimeSpan(0, 4, 44), IsAdminApproved = 1 },
                new Song { SongID = 2, AlbumID = 1, Name = "Paranoid Android", Order = 2, Length = new TimeSpan(0, 6, 23), IsAdminApproved = 1 },
                new Song { SongID = 3, AlbumID = 1, Name = "Subterranean Homesick Alien", Order = 3, Length = new TimeSpan(0, 4, 27), IsAdminApproved = 1 },
                new Song { SongID = 4, AlbumID = 1, Name = "Exit Music (For a Film)", Order = 4, Length = new TimeSpan(0, 4, 24), IsAdminApproved = 1 },
                new Song { SongID = 5, AlbumID = 1, Name = "Let Down", Order = 5, Length = new TimeSpan(0, 4, 59), IsAdminApproved = 1 },
                new Song { SongID = 6, AlbumID = 1, Name = "Karma Police", Order = 6, Length = new TimeSpan(0, 4, 21), IsAdminApproved = 1 },
                new Song { SongID = 7, AlbumID = 1, Name = "Fitter Happier", Order = 7, Length = new TimeSpan(0, 1, 57), IsAdminApproved = 1 },
                new Song { SongID = 8, AlbumID = 1, Name = "Electioneering", Order = 8, Length = new TimeSpan(0, 3, 50), IsAdminApproved = 1 },
                new Song { SongID = 9, AlbumID = 1, Name = "Climbing Up the Walls", Order = 9, Length = new TimeSpan(0, 4, 45), IsAdminApproved = 1 },
                new Song { SongID = 10, AlbumID = 1, Name = "No Surprises", Order = 10, Length = new TimeSpan(0, 3, 48), IsAdminApproved = 1 },
                new Song { SongID = 11, AlbumID = 1, Name = "Lucky", Order = 11, Length = new TimeSpan(0, 4, 19), IsAdminApproved = 1 },
                new Song { SongID = 12, AlbumID = 1, Name = "The Tourist", Order = 12, Length = new TimeSpan(0, 5, 24), IsAdminApproved = 1 },
                new Song { SongID = 13, AlbumID = 2, Name = "Everything in Its Right Place", Order = 1, Length = new TimeSpan(0, 4, 11), IsAdminApproved = 1 },
                new Song { SongID = 14, AlbumID = 2, Name = "Kid A", Order = 2, Length = new TimeSpan(0, 4, 44), IsAdminApproved = 1 },
                new Song { SongID = 15, AlbumID = 2, Name = "The National Anthem", Order = 3, Length = new TimeSpan(0, 5, 51), IsAdminApproved = 1 },
                new Song { SongID = 16, AlbumID = 2, Name = "How to Disappear Completely", Order = 4, Length = new TimeSpan(0, 5, 56), IsAdminApproved = 1 },
                new Song { SongID = 17, AlbumID = 2, Name = "Treefingers", Order = 5, Length = new TimeSpan(0, 3, 42), IsAdminApproved = 1 },
                new Song { SongID = 18, AlbumID = 2, Name = "Optimistic", Order = 6, Length = new TimeSpan(0, 5, 15), IsAdminApproved = 1 },
                new Song { SongID = 19, AlbumID = 2, Name = "In Limbo", Order = 7, Length = new TimeSpan(0, 3, 31), IsAdminApproved = 1 },
                new Song { SongID = 20, AlbumID = 2, Name = "Idioteque", Order = 8, Length = new TimeSpan(0, 5, 9), IsAdminApproved = 1 },
                new Song { SongID = 21, AlbumID = 2, Name = "Morning Bell", Order = 9, Length = new TimeSpan(0, 4, 35), IsAdminApproved = 1 },
                new Song { SongID = 22, AlbumID = 2, Name = "Motion Picture Soundtrack", Order = 10, Length = new TimeSpan(0, 7, 01), IsAdminApproved = 1 },
                new Song { SongID = 23, AlbumID = 3, Name = "15 Step", Order = 1, Length = new TimeSpan(0, 3, 58), IsAdminApproved = 1 },
                new Song { SongID = 24, AlbumID = 3, Name = "Bodysnatchers", Order = 2, Length = new TimeSpan(0, 4, 2), IsAdminApproved = 1 },
                new Song { SongID = 25, AlbumID = 3, Name = "Nude", Order = 3, Length = new TimeSpan(0, 4, 15), IsAdminApproved = 1 },
                new Song { SongID = 26, AlbumID = 3, Name = "Weird Fishes/Arpeggi", Order = 4, Length = new TimeSpan(0, 5, 18), IsAdminApproved = 1 },
                new Song { SongID = 27, AlbumID = 3, Name = "All I Need", Order = 5, Length = new TimeSpan(0, 3, 49), IsAdminApproved = 1 },
                new Song { SongID = 28, AlbumID = 3, Name = "Faust Arp", Order = 6, Length = new TimeSpan(0, 2, 10), IsAdminApproved = 1 },
                new Song { SongID = 29, AlbumID = 3, Name = "Reckoner", Order = 7, Length = new TimeSpan(0, 4, 50), IsAdminApproved = 1 },
                new Song { SongID = 30, AlbumID = 3, Name = "House of Cards", Order = 8, Length = new TimeSpan(0, 5, 28), IsAdminApproved = 1 },
                new Song { SongID = 31, AlbumID = 3, Name = "Jigsaw Falling into Place", Order = 9, Length = new TimeSpan(0, 4, 9), IsAdminApproved = 1 },
                new Song { SongID = 32, AlbumID = 3, Name = "Videotape", Order = 10, Length = new TimeSpan(0, 4, 40), IsAdminApproved = 1 },
                new Song { SongID = 33, AlbumID = 4, Name = "Dragons", Order = 1, Length = new TimeSpan(0, 4, 5), IsAdminApproved = 1},
                new Song { SongID = 34, AlbumID = 4, Name = "Star Scat", Order = 2, Length = new TimeSpan(0, 3, 50), IsAdminApproved = 1 },
                new Song { SongID = 35, AlbumID = 4, Name = "Ended With the Night", Order = 3, Length = new TimeSpan(0, 5, 0), IsAdminApproved = 1 },
                new Song { SongID = 36, AlbumID = 4, Name = "Jolie Coquine", Order = 4, Length = new TimeSpan(0, 3, 46), IsAdminApproved = 1 },
                new Song { SongID = 37, AlbumID = 4, Name = "Oooh", Order = 5, Length = new TimeSpan(0, 1, 49), IsAdminApproved = 1 },
                new Song { SongID = 38, AlbumID = 4, Name = "Suzy", Order = 6, Length = new TimeSpan(0, 4, 7), IsAdminApproved = 1 },
                new Song { SongID = 39, AlbumID = 4, Name = "Je M'Amuse", Order = 7, Length = new TimeSpan(0, 3, 34), IsAdminApproved = 1 },
                new Song { SongID = 40, AlbumID = 4, Name = "Violente Valse", Order = 8, Length = new TimeSpan(0, 3, 35), IsAdminApproved = 1 },
                new Song { SongID = 41, AlbumID = 4, Name = "Brotherswing", Order = 9, Length = new TimeSpan(0, 3, 42), IsAdminApproved = 1 },
                new Song { SongID = 42, AlbumID = 4, Name = "L'Envol", Order = 10, Length = new TimeSpan(0, 3, 46), IsAdminApproved = 1 },
                new Song { SongID = 43, AlbumID = 4, Name = "Sofa", Order = 11, Length = new TimeSpan(0, 0, 51), IsAdminApproved = 1 },
                new Song { SongID = 44, AlbumID = 4, Name = "Bambous", Order = 12, Length = new TimeSpan(0, 3, 14), IsAdminApproved = 1 },
                new Song { SongID = 45, AlbumID = 4, Name = "Lazy Place", Order = 13, Length = new TimeSpan(0, 3, 57), IsAdminApproved = 1 },
                new Song { SongID = 46, AlbumID = 4, Name = "We Can Dance", Order = 14, Length = new TimeSpan(0, 4, 23), IsAdminApproved = 1 },
                new Song { SongID = 47, AlbumID = 4, Name = "La Caravane", Order = 15, Length = new TimeSpan(0, 5, 5), IsAdminApproved = 1 }
            );

            context.UserArtist.AddOrUpdate(
                new UserArtist { UserID = "2e8b2696-e229-4dad-a9de-c0fe56359361", ArtistID = 4, IsRanked = true, Ranking = 1 },
                new UserArtist { UserID = "2e8b2696-e229-4dad-a9de-c0fe56359361", ArtistID = 12, IsRanked = true, Ranking = 2 }
            );

            context.Flag.AddOrUpdate(
                new Flag { FlagID = 7, Name = "Offensive Content" },
                new Flag { FlagID = 8, Name = "Flaming" }
            );
        }
    }
}
