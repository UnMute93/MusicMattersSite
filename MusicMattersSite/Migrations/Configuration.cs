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
                new Album { AlbumID = 4, ArtistID = 12, Name = "Caravan Palace", Image = "~/Images/Artists/Caravan Palace/caravan_palace_cover.jpg", ReleaseDate = new DateTime(2008, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 5, ArtistID = 12, Name = "Panic", Image = "~/Images/Artists/Caravan Palace/panic_cover.jpg", ReleaseDate = new DateTime(2012, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 6, ArtistID = 12, Name = "<|°_°|>", Image = "~/Images/Artists/Caravan Palace/robot_cover.jpg", ReleaseDate = new DateTime(2015, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 7, ArtistID = 4, Name = "Pablo Honey", Image = "~/Images/Artists/Radiohead/pablo_honey_cover.jpg", ReleaseDate = new DateTime(1993, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 8, ArtistID = 4, Name = "The Bends", Image = "~/Images/Artists/Radiohead/the_bends_cover.jpg", ReleaseDate = new DateTime(1995, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 9, ArtistID = 4, Name = "Amnesiac", Image = "~/Images/Artists/Radiohead/amnesiac_cover.jpg", ReleaseDate = new DateTime(2001, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 10, ArtistID = 4, Name = "Hail to the Thief", Image = "~/Images/Artists/Radiohead/hail_to_the_thief_cover.jpg", ReleaseDate = new DateTime(2003, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 11, ArtistID = 4, Name = "The King of Limbs", Image = "~/Images/Artists/Radiohead/the_king_of_limbs_cover.jpg", ReleaseDate = new DateTime(2011, 1, 1), IsAdminApproved = 1 },
                new Album { AlbumID = 12, ArtistID = 4, Name = "A Moon Shaped Pool", Image = "~/Images/Artists/Radiohead/a_moon_shaped_pool_cover.jpg", ReleaseDate = new DateTime(2016, 1, 1), IsAdminApproved = 1 }
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
                new Song { SongID = 47, AlbumID = 4, Name = "La Caravane", Order = 15, Length = new TimeSpan(0, 5, 5), IsAdminApproved = 1 },
                new Song { SongID = 48, AlbumID = 5, Name = "Queens", Order = 1, Length = new TimeSpan(0, 4, 6), IsAdminApproved = 1 },
                new Song { SongID = 49, AlbumID = 5, Name = "Maniac", Order = 2, Length = new TimeSpan(0, 4, 11), IsAdminApproved = 1 },
                new Song { SongID = 50, AlbumID = 5, Name = "The Dirty Side of the Street", Order = 3, Length = new TimeSpan(0, 3, 39), IsAdminApproved = 1 },
                new Song { SongID = 51, AlbumID = 5, Name = "12 Juin 3049", Order = 4, Length = new TimeSpan(0, 3, 23), IsAdminApproved = 1 },
                new Song { SongID = 52, AlbumID = 5, Name = "Rock It for Me", Order = 5, Length = new TimeSpan(0, 3, 12), IsAdminApproved = 1 },
                new Song { SongID = 53, AlbumID = 5, Name = "Clash", Order = 6, Length = new TimeSpan(0, 4, 13), IsAdminApproved = 1 },
                new Song { SongID = 54, AlbumID = 5, Name = "Newbop", Order = 7, Length = new TimeSpan(0, 2, 51), IsAdminApproved = 1 },
                new Song { SongID = 55, AlbumID = 5, Name = "Glory of Nelly", Order = 8, Length = new TimeSpan(0, 3, 45), IsAdminApproved = 1 },
                new Song { SongID = 56, AlbumID = 5, Name = "Dramophone", Order = 9, Length = new TimeSpan(0, 3, 24), IsAdminApproved = 1 },
                new Song { SongID = 57, AlbumID = 5, Name = "Cotton Heads", Order = 10, Length = new TimeSpan(0, 3, 38), IsAdminApproved = 1 },
                new Song { SongID = 58, AlbumID = 5, Name = "Panic", Order = 11, Length = new TimeSpan(0, 4, 5), IsAdminApproved = 1 },
                new Song { SongID = 59, AlbumID = 5, Name = "Pirates", Order = 12, Length = new TimeSpan(0, 3, 20), IsAdminApproved = 1 },
                new Song { SongID = 60, AlbumID = 5, Name = "Beatophone", Order = 13, Length = new TimeSpan(0, 3, 54), IsAdminApproved = 1 },
                new Song { SongID = 61, AlbumID = 5, Name = "Sydney", Order = 14, Length = new TimeSpan(0, 3, 32), IsAdminApproved = 1 },
                new Song { SongID = 62, AlbumID = 6, Name = "Lone Digger", Order = 1, Length = new TimeSpan(0, 3, 49), IsAdminApproved = 1 },
                new Song { SongID = 63, AlbumID = 6, Name = "Comics", Order = 2, Length = new TimeSpan(0, 3, 32), IsAdminApproved = 1 },
                new Song { SongID = 64, AlbumID = 6, Name = "Mighty", Order = 3, Length = new TimeSpan(0, 3, 21), IsAdminApproved = 1 },
                new Song { SongID = 65, AlbumID = 6, Name = "Aftermath", Order = 4, Length = new TimeSpan(0, 3, 5), IsAdminApproved = 1 },
                new Song { SongID = 66, AlbumID = 6, Name = "Wonderland", Order = 5, Length = new TimeSpan(0, 3, 10), IsAdminApproved = 1 },
                new Song { SongID = 67, AlbumID = 6, Name = "Tattoos", Order = 6, Length = new TimeSpan(0, 3, 27), IsAdminApproved = 1 },
                new Song { SongID = 68, AlbumID = 6, Name = "Midnight", Order = 7, Length = new TimeSpan(0, 3, 25), IsAdminApproved = 1 },
                new Song { SongID = 69, AlbumID = 6, Name = "Russian", Order = 8, Length = new TimeSpan(0, 4, 1), IsAdminApproved = 1 },
                new Song { SongID = 70, AlbumID = 6, Name = "Wonda", Order = 9, Length = new TimeSpan(0, 3, 44), IsAdminApproved = 1 },
                new Song { SongID = 71, AlbumID = 6, Name = "Human Leather Shoes for Crocodile Dandies", Order = 10, Length = new TimeSpan(0, 4, 33), IsAdminApproved = 1 },
                new Song { SongID = 72, AlbumID = 6, Name = "Lay Down", Order = 11, Length = new TimeSpan(0, 3, 8), IsAdminApproved = 1 },
                new Song { SongID = 73, AlbumID = 7, Name = "You", Order = 1, Length = new TimeSpan(0, 3, 29), IsAdminApproved = 1 },
                new Song { SongID = 74, AlbumID = 7, Name = "Creep", Order = 2, Length = new TimeSpan(0, 3, 56), IsAdminApproved = 1 },
                new Song { SongID = 75, AlbumID = 7, Name = "How Do you?", Order = 3, Length = new TimeSpan(0, 2, 12), IsAdminApproved = 1 },
                new Song { SongID = 76, AlbumID = 7, Name = "Stop Whispering", Order = 4, Length = new TimeSpan(0, 5, 26), IsAdminApproved = 1 },
                new Song { SongID = 77, AlbumID = 7, Name = "Thinking About You", Order = 5, Length = new TimeSpan(0, 2, 41), IsAdminApproved = 1 },
                new Song { SongID = 78, AlbumID = 7, Name = "Anyone Can Play Guitar", Order = 6, Length = new TimeSpan(0, 3, 38), IsAdminApproved = 1 },
                new Song { SongID = 79, AlbumID = 7, Name = "Ripcord", Order = 7, Length = new TimeSpan(0, 3, 10), IsAdminApproved = 1 },
                new Song { SongID = 80, AlbumID = 7, Name = "Vegetable", Order = 8, Length = new TimeSpan(0, 3, 13), IsAdminApproved = 1 },
                new Song { SongID = 81, AlbumID = 7, Name = "Prove Yourself", Order = 9, Length = new TimeSpan(0, 2, 25), IsAdminApproved = 1 },
                new Song { SongID = 82, AlbumID = 7, Name = "I Can't", Order = 10, Length = new TimeSpan(0, 4, 13), IsAdminApproved = 1 },
                new Song { SongID = 83, AlbumID = 7, Name = "Lurgee", Order = 11, Length = new TimeSpan(0, 3, 8), IsAdminApproved = 1 },
                new Song { SongID = 84, AlbumID = 7, Name = "Blow Out", Order = 12, Length = new TimeSpan(0, 4, 40), IsAdminApproved = 1 },
                new Song { SongID = 85, AlbumID = 8, Name = "Planet Telex", Order = 1, Length = new TimeSpan(0, 4, 19), IsAdminApproved = 1 },
                new Song { SongID = 86, AlbumID = 8, Name = "The Bends", Order = 2, Length = new TimeSpan(0, 4, 6), IsAdminApproved = 1 },
                new Song { SongID = 87, AlbumID = 8, Name = "High and Dry", Order = 3, Length = new TimeSpan(0, 4, 17), IsAdminApproved = 1 },
                new Song { SongID = 88, AlbumID = 8, Name = "Fake Plastic Trees", Order = 4, Length = new TimeSpan(0, 4, 50), IsAdminApproved = 1 },
                new Song { SongID = 89, AlbumID = 8, Name = "Bones", Order = 5, Length = new TimeSpan(0, 3, 9), IsAdminApproved = 1 },
                new Song { SongID = 90, AlbumID = 8, Name = "(Nice Dream)", Order = 6, Length = new TimeSpan(0, 3, 53), IsAdminApproved = 1 },
                new Song { SongID = 91, AlbumID = 8, Name = "Just", Order = 7, Length = new TimeSpan(0, 3, 54), IsAdminApproved = 1 },
                new Song { SongID = 92, AlbumID = 8, Name = "My Iron Lung", Order = 8, Length = new TimeSpan(0, 4, 36), IsAdminApproved = 1 },
                new Song { SongID = 93, AlbumID = 8, Name = "Bullet Proof..I Wish I Was", Order = 9, Length = new TimeSpan(0, 3, 28), IsAdminApproved = 1 },
                new Song { SongID = 94, AlbumID = 8, Name = "Black Star", Order = 10, Length = new TimeSpan(0, 4, 7), IsAdminApproved = 1 },
                new Song { SongID = 95, AlbumID = 8, Name = "Sulk", Order = 11, Length = new TimeSpan(0, 3, 42), IsAdminApproved = 1 },
                new Song { SongID = 96, AlbumID = 8, Name = "Street Spirit (Fade Out)", Order = 12, Length = new TimeSpan(0, 4, 12), IsAdminApproved = 1 },
                new Song { SongID = 97, AlbumID = 9, Name = "Packt Like Sardines in a Crushd Tin Box", Order = 1, Length = new TimeSpan(0, 4, 0), IsAdminApproved = 1 },
                new Song { SongID = 98, AlbumID = 9, Name = "Pyramid Song", Order = 2, Length = new TimeSpan(0, 4, 49), IsAdminApproved = 1 },
                new Song { SongID = 99, AlbumID = 9, Name = "Pulk/Pull Revolving Doors", Order = 3, Length = new TimeSpan(0, 4, 7), IsAdminApproved = 1 },
                new Song { SongID = 100, AlbumID = 9, Name = "You and Whose Army?", Order = 4, Length = new TimeSpan(0, 3, 11), IsAdminApproved = 1 },
                new Song { SongID = 101, AlbumID = 9, Name = "I Might Be Wrong", Order = 5, Length = new TimeSpan(0, 4, 54), IsAdminApproved = 1 },
                new Song { SongID = 102, AlbumID = 9, Name = "Knives Out", Order = 6, Length = new TimeSpan(0, 4, 15), IsAdminApproved = 1 },
                new Song { SongID = 103, AlbumID = 9, Name = "Morning Bell/Amnesiac", Order = 7, Length = new TimeSpan(0, 3, 14), IsAdminApproved = 1 },
                new Song { SongID = 104, AlbumID = 9, Name = "Dollars and Cents", Order = 8, Length = new TimeSpan(0, 4, 52), IsAdminApproved = 1 },
                new Song { SongID = 105, AlbumID = 9, Name = "Hunting Bears", Order = 9, Length = new TimeSpan(0, 2, 1), IsAdminApproved = 1 },
                new Song { SongID = 106, AlbumID = 9, Name = "Like Spinning Plates", Order = 10, Length = new TimeSpan(0, 3, 57), IsAdminApproved = 1 },
                new Song { SongID = 107, AlbumID = 9, Name = "Life in a Glasshouse", Order = 11, Length = new TimeSpan(0, 4, 34), IsAdminApproved = 1 },
                new Song { SongID = 108, AlbumID = 10, Name = "2 + 2 = 5", Order = 1, Length = new TimeSpan(0, 3, 19), IsAdminApproved = 1 },
                new Song { SongID = 109, AlbumID = 10, Name = "Sit down. Stand up.", Order = 2, Length = new TimeSpan(0, 4, 19), IsAdminApproved = 1 },
                new Song { SongID = 110, AlbumID = 10, Name = "Sail to the Moon", Order = 3, Length = new TimeSpan(0, 4, 18), IsAdminApproved = 1 },
                new Song { SongID = 111, AlbumID = 10, Name = "Backdrifts", Order = 4, Length = new TimeSpan(0, 5, 22), IsAdminApproved = 1 },
                new Song { SongID = 112, AlbumID = 10, Name = "Go to Sleep", Order = 5, Length = new TimeSpan(0, 3, 21), IsAdminApproved = 1 },
                new Song { SongID = 113, AlbumID = 10, Name = "Where I End and You Begin", Order = 6, Length = new TimeSpan(0, 4, 29), IsAdminApproved = 1 },
                new Song { SongID = 114, AlbumID = 10, Name = "We suck Young Blood", Order = 7, Length = new TimeSpan(0, 4, 56), IsAdminApproved = 1 },
                new Song { SongID = 115, AlbumID = 10, Name = "The Gloaming", Order = 8, Length = new TimeSpan(0, 3, 32), IsAdminApproved = 1 },
                new Song { SongID = 116, AlbumID = 10, Name = "There there", Order = 9, Length = new TimeSpan(0, 5, 25), IsAdminApproved = 1 },
                new Song { SongID = 117, AlbumID = 10, Name = "I will", Order = 10, Length = new TimeSpan(0, 1, 59), IsAdminApproved = 1 },
                new Song { SongID = 118, AlbumID = 10, Name = "A Punchup at a Wedding", Order = 11, Length = new TimeSpan(0, 4, 57), IsAdminApproved = 1 },
                new Song { SongID = 119, AlbumID = 10, Name = "Myxomatosis", Order = 12, Length = new TimeSpan(0, 3, 52), IsAdminApproved = 1 },
                new Song { SongID = 120, AlbumID = 10, Name = "Scatterbrain", Order = 13, Length = new TimeSpan(0, 3, 21), IsAdminApproved = 1 },
                new Song { SongID = 121, AlbumID = 10, Name = "A Wolf at the Door", Order = 14, Length = new TimeSpan(0, 3, 21), IsAdminApproved = 1 },
                new Song { SongID = 122, AlbumID = 11, Name = "Bloom", Order = 1, Length = new TimeSpan(0, 5, 15), IsAdminApproved = 1 },
                new Song { SongID = 123, AlbumID = 11, Name = "Morning Mr Magpie", Order = 2, Length = new TimeSpan(0, 4, 41), IsAdminApproved = 1 },
                new Song { SongID = 124, AlbumID = 11, Name = "Little by Little", Order = 3, Length = new TimeSpan(0, 4, 27), IsAdminApproved = 1 },
                new Song { SongID = 125, AlbumID = 11, Name = "Feral", Order = 4, Length = new TimeSpan(0, 3, 13), IsAdminApproved = 1 },
                new Song { SongID = 126, AlbumID = 11, Name = "Lotus Flower", Order = 5, Length = new TimeSpan(0, 5, 1), IsAdminApproved = 1 },
                new Song { SongID = 127, AlbumID = 11, Name = "Codex", Order = 6, Length = new TimeSpan(0, 4, 47), IsAdminApproved = 1 },
                new Song { SongID = 128, AlbumID = 11, Name = "Give Up the Ghost", Order = 7, Length = new TimeSpan(0, 4, 50), IsAdminApproved = 1 },
                new Song { SongID = 129, AlbumID = 11, Name = "Separator", Order = 8, Length = new TimeSpan(0, 5, 20), IsAdminApproved = 1 },
                new Song { SongID = 130, AlbumID = 12, Name = "Burn the Witch", Order = 1, Length = new TimeSpan(0, 3, 40), IsAdminApproved = 1 },
                new Song { SongID = 131, AlbumID = 12, Name = "Daydreaming", Order = 2, Length = new TimeSpan(0, 6, 24), IsAdminApproved = 1 },
                new Song { SongID = 132, AlbumID = 12, Name = "Decks Dark", Order = 3, Length = new TimeSpan(0, 4, 41), IsAdminApproved = 1 },
                new Song { SongID = 133, AlbumID = 12, Name = "Desert Island Disk", Order = 4, Length = new TimeSpan(0, 3, 44), IsAdminApproved = 1 },
                new Song { SongID = 134, AlbumID = 12, Name = "Ful Stop", Order = 5, Length = new TimeSpan(0, 6, 7), IsAdminApproved = 1 },
                new Song { SongID = 135, AlbumID = 12, Name = "Glass Eyes", Order = 6, Length = new TimeSpan(0, 2, 52), IsAdminApproved = 1 },
                new Song { SongID = 136, AlbumID = 12, Name = "Identikit", Order = 7, Length = new TimeSpan(0, 4, 26), IsAdminApproved = 1 },
                new Song { SongID = 137, AlbumID = 12, Name = "The Numbers", Order = 8, Length = new TimeSpan(0, 5, 45), IsAdminApproved = 1 },
                new Song { SongID = 138, AlbumID = 12, Name = "Present Tense", Order = 9, Length = new TimeSpan(0, 5, 6), IsAdminApproved = 1 },
                new Song { SongID = 139, AlbumID = 12, Name = "Tinker Tailor Soldier Sailor Rich Man Poor Man Beggar Man Thief", Order = 10, Length = new TimeSpan(0, 5, 3), IsAdminApproved = 1 },
                new Song { SongID = 140, AlbumID = 12, Name = "True Love Waits", Order = 11, Length = new TimeSpan(0, 4, 43), IsAdminApproved = 1 }
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
