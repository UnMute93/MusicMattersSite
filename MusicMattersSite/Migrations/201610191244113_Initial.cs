namespace MusicMattersSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        ArtistID = c.Int(nullable: false),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(),
                        Image = c.String(),
                        IsAdminApproved = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artists", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        ActiveFrom = c.DateTime(),
                        ActiveUntil = c.DateTime(),
                        IsAdminApproved = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.UserArtists",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        ArtistID = c.Int(nullable: false),
                        Ranking = c.Int(),
                        IsRanked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ArtistID })
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ArtistID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Length = c.Time(precision: 7),
                        Order = c.Int(nullable: false),
                        IsSingle = c.Byte(),
                        IsAdminApproved = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SongID)
                .ForeignKey("dbo.Albums", t => t.AlbumID, cascadeDelete: true)
                .Index(t => t.AlbumID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserAuthorID = c.String(nullable: false, maxLength: 128),
                        UserRecipientID = c.String(nullable: false, maxLength: 128),
                        ParentID = c.Int(nullable: false),
                        SortKey = c.String(),
                        Content = c.String(nullable: false),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeEdited = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAuthorID, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserRecipientID, cascadeDelete: false)
                .Index(t => t.UserAuthorID)
                .Index(t => t.UserRecipientID);
            
            CreateTable(
                "dbo.CommentHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Action = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Flags",
                c => new
                    {
                        FlagID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FlagID);
            
            CreateTable(
                "dbo.Flaggables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlagID = c.Int(nullable: false),
                        FlaggableType = c.String(nullable: false),
                        FlaggableID = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flags", t => t.FlagID, cascadeDelete: true)
                .Index(t => t.FlagID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Bio = c.String(),
                        BackgroundColor = c.String(nullable: false),
                        ShowEmail = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateStoredProcedure(
                "dbo.comment_insert_sortkey",
                p => new
                    {
                        UserAuthorID = p.String(maxLength: 128),
                        UserRecipientID = p.String(maxLength: 128),
                        ParentID = p.Int(),
                        SortKey = p.String(),
                        Content = p.String(),
                        TimeCreated = p.DateTime(),
                        TimeEdited = p.DateTime(),
                    },
                body:
                    @"DECLARE @SortKeyPrefix [nvarchar](MAX)
	                  DECLARE @VarCharID [nvarchar](100)

                      SET @SortKeyPrefix = [nvarchar](MAX)(SELECT c.SortKey FROM [dbo].[Comments] c WHERE c.CommentID = @ParentID)
                      SET @VarCharID = CONVERT([nvarchar](100), SCOPE_IDENTITY())

	                  IF (@SortKeyPrefix IS NOT NULL)
		              SET @SortKey = @SortKeyPrefix + '.';
	                  SET @SortKey += REPLICATE(0, 4-LEN(@VarCharID)) + @VarCharID

                      INSERT [dbo].[Comments]([UserAuthorID], [UserRecipientID], [ParentID], [SortKey], [Content], [TimeCreated], [TimeEdited])
                      VALUES (@UserAuthorID, @UserRecipientID, @ParentID, @SortKey, @Content, @TimeCreated, @TimeEdited)
                      
                      DECLARE @CommentID int
                      SELECT @CommentID = [CommentID]
                      FROM [dbo].[Comments]
                      WHERE @@ROWCOUNT > 0 AND [CommentID] = scope_identity()
                      
                      SELECT t0.[CommentID]
                      FROM [dbo].[Comments] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CommentID] = @CommentID"
            );
            
            CreateStoredProcedure(
                "dbo.Comment_Update",
                p => new
                    {
                        CommentID = p.Int(),
                        UserAuthorID = p.String(maxLength: 128),
                        UserRecipientID = p.String(maxLength: 128),
                        ParentID = p.Int(),
                        SortKey = p.String(),
                        Content = p.String(),
                        TimeCreated = p.DateTime(),
                        TimeEdited = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Comments]
                      SET [UserAuthorID] = @UserAuthorID, [UserRecipientID] = @UserRecipientID, [ParentID] = @ParentID, [SortKey] = @SortKey, [Content] = @Content, [TimeCreated] = @TimeCreated, [TimeEdited] = @TimeEdited
                      WHERE ([CommentID] = @CommentID)"
            );
            
            CreateStoredProcedure(
                "dbo.Comment_Delete",
                p => new
                    {
                        CommentID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Comments]
                      WHERE ([CommentID] = @CommentID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Comment_Delete");
            DropStoredProcedure("dbo.Comment_Update");
            DropStoredProcedure("dbo.comment_insert_sortkey");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProfiles", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Flaggables", "FlagID", "dbo.Flags");
            DropForeignKey("dbo.Comments", "UserRecipientID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserAuthorID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Songs", "AlbumID", "dbo.Albums");
            DropForeignKey("dbo.UserArtists", "ArtistID", "dbo.Artists");
            DropForeignKey("dbo.UserArtists", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Albums", "ArtistID", "dbo.Artists");
            DropIndex("dbo.UserProfiles", new[] { "UserID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Flaggables", new[] { "FlagID" });
            DropIndex("dbo.Comments", new[] { "UserRecipientID" });
            DropIndex("dbo.Comments", new[] { "UserAuthorID" });
            DropIndex("dbo.Songs", new[] { "AlbumID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserArtists", new[] { "ArtistID" });
            DropIndex("dbo.UserArtists", new[] { "UserID" });
            DropIndex("dbo.Albums", new[] { "ArtistID" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Flaggables");
            DropTable("dbo.Flags");
            DropTable("dbo.CommentHistories");
            DropTable("dbo.Comments");
            DropTable("dbo.Songs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserArtists");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
