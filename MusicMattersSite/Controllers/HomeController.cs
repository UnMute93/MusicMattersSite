using Microsoft.AspNet.Identity;
using MusicMattersSite.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace MusicMattersSite.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<string> model = new List<string>();
            using (var db = new ApplicationDbContext())
            {
                var userResult = from item in db.AppUser
                                 orderby item.UserName
                                 select item.UserName;
                model = userResult.ToList();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Profiles(string UserName)
        {
            ProfileViewModel model = new ProfileViewModel();
            if (UserName != null)
            {
                
                var userResult = from item in db.AppUser
                                    where item.UserName == UserName
                                    select item;
                ApplicationUser user = userResult.FirstOrDefault();
                if (user != null)
                {
                    var profileResult = from item in db.UserProfile
                                        where item.UserID == user.Id
                                        select item;
                    UserProfile profile = profileResult.FirstOrDefault();

                    var commentsResult = from item in db.Comment
                                            join appuser in db.AppUser
                                            on item.UserRecipientID equals appuser.Id
                                            where item.UserRecipientID == user.Id
                                            orderby item.SortKey ascending
                                            select new { item, item.UserAuthor.UserName };
                    List<ProfileComment> commentList = new List<ProfileComment>();
                    foreach (var item in commentsResult)
                    {
                        ProfileComment pc = new ProfileComment();
                        pc.CommentID = item.item.CommentID;
                        pc.AuthorID = item.item.UserAuthorID;
                        pc.AuthorName = item.UserName;
                        pc.Content = item.item.Content;
                        pc.TimeCreated = item.item.TimeCreated;
                        pc.TimeEdited = item.item.TimeEdited;
                        pc.SortKey = item.item.SortKey;
                        commentList.Add(pc);
                    }

                    var artistsResult = from item in db.Artist
                                        join ranking in db.UserArtist
                                        on item.ArtistID equals ranking.ArtistID
                                        join u in db.AppUser
                                        on ranking.UserID equals u.Id
                                        where u.Id == user.Id
                                        orderby ranking.IsRanked descending, ranking.Ranking ascending
                                        select new { item.ArtistID, item.Name, ranking.Ranking };
                    List<ArtistRanking> artistList = new List<ArtistRanking>();
                    foreach (var item in artistsResult)
                    {
                        ArtistRanking ar = new ArtistRanking();
                        ar.ArtistID = item.ArtistID;
                        ar.ArtistName = item.Name;
                        ar.Ranking = item.Ranking ?? 0;
                        artistList.Add(ar);
                    }

                    var flagsResult = from item in db.Flag
                                      select item;
                    List<Flag> flagList = new List<Flag>();
                    foreach (var item in flagsResult)
                    {
                        Flag f = new Flag();
                        f.FlagID = item.FlagID;
                        f.Name = item.Name;
                        flagList.Add(f);
                    }

                    model.UserID = user.Id;
                    model.UserName = user.UserName;
                    model.Email = user.Email;
                    model.Bio = profile.Bio;
                    model.ShowEmail = profile.ShowEmail;
                    model.Comments = commentList;
                    model.Artists = artistList;
                    model.Flags = flagList;
                    
                    return View(model);
                }
            }
            return Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditProfileSettings(string userID)
        {
            if (User.Identity.GetUserId() == userID)
            {
                EditProfileSettingsViewModel model = new EditProfileSettingsViewModel();

                var profileResult = (from item in db.UserProfile
                                     where item.UserID == userID
                                     select item).FirstOrDefault();

                model.Bio = profileResult.Bio;
                model.ShowEmail = profileResult.ShowEmail;

                model.Artists = new List<ArtistRanking>();

                var artistResult = from a in db.Artist
                                   join ua in db.UserArtist
                                   on a.ArtistID equals ua.ArtistID
                                   join u in db.AppUser
                                   on ua.UserID equals u.Id
                                   where u.Id == userID
                                   orderby ua.IsRanked descending, ua.Ranking ascending, a.Name descending
                                   select new { a.ArtistID, a.Name, ua.Ranking };

                foreach (var item in artistResult)
                {
                    ArtistRanking ar = new ArtistRanking();
                    ar.ArtistID = item.ArtistID;
                    ar.ArtistName = item.Name;
                    ar.Ranking = item.Ranking ?? 0;

                    model.Artists.Add(ar);
                }

                return View(model);
            }
            return Redirect("/");
        }
        [HttpPost]
        [Authorize]
        public ActionResult EditProfileSettings(EditProfileSettingsViewModel model, int ShowEmail)
        {
            if (ModelState.IsValid)
            {
                var profileResult = from item in db.UserProfile
                                    where item.UserID == model.UserID
                                    select item;

                profileResult.FirstOrDefault().Bio = model.Bio;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    LogError(e);
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e.Message);
                    LogError(e);
                }
            }
            return Redirect("/");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ReportComment(ProfileViewModel model, int CommentIndex)
        {
            Flaggable flaggable = new Flaggable();
            flaggable.FlagID = model.Flag.FlagID;
            flaggable.FlaggableType = "Comment";
            flaggable.FlaggableID = model.Comments[CommentIndex].CommentID;
            flaggable.Time = DateTime.Now;

            db.Flaggable.Add(flaggable);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                LogError(e);
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
                LogError(e);
            }

            return RedirectToAction("Profiles", new { UserName = model.UserName });
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(ProfileViewModel model, int ParentID)
        {
            if (ModelState.IsValidField("Comment.Content"))
            {
                string sortKey = "";

                model.Comment.TimeCreated = DateTime.Now;
                model.Comment.UserAuthorID = User.Identity.GetUserId();
                model.Comment.UserRecipientID = model.UserID;
                model.Comment.ParentID = ParentID;

                db.Comment.Add(model.Comment);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    LogError(e);
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e.Message);
                    LogError(e);
                }



                var prefixResult = from item in db.Comment
                                    where item.CommentID == model.Comment.ParentID
                                    select item.SortKey;
                if (prefixResult.FirstOrDefault() != null)
                {
                    sortKey = prefixResult.FirstOrDefault() + ".";
                }

                sortKey += model.Comment.CommentID.ToString("D4"); //Pads the string with 4 zeroes
                model.Comment.SortKey = sortKey;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    LogError(e);
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e.Message);
                    LogError(e);
                }
            }
            return RedirectToAction("Profiles", new { UserName = model.UserName });
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditComment(ProfileViewModel model, int CommentIndex)
        {
            if (ModelState.IsValidField("Comment.Content") && User.Identity.GetUserId() == model.Comments[CommentIndex].AuthorID)
            {
                int id = model.Comments[CommentIndex].CommentID;
                var commentResult = (from item in db.Comment
                                    where item.CommentID == id
                                    select item).FirstOrDefault();
                if (commentResult != null)
                {
                    CreateCommentHistory(commentResult, "UPD");
                    commentResult.Content = model.Comments[CommentIndex].Content;
                    commentResult.TimeEdited = DateTime.Now;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException e)
                    {
                        Console.WriteLine(e.Message);
                        LogError(e);
                    }
                    catch (DbEntityValidationException e)
                    {
                        Console.WriteLine(e.Message);
                        LogError(e);
                    }
                }
            }

            return RedirectToAction("Profiles", new { UserName = model.UserName });
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteComment(ProfileViewModel model, int CommentIndex)
        {
            if (ModelState.IsValidField("Comment.Content") && User.Identity.GetUserId() == model.Comments[CommentIndex].AuthorID)
            {
                int id = model.Comments[CommentIndex].CommentID;
                var commentResult = (from item in db.Comment
                                     where item.CommentID == id
                                     select item).FirstOrDefault();
                if (commentResult != null)
                {
                    CreateCommentHistory(commentResult, "DEL");
                    db.Comment.Remove(commentResult);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateException e)
                    {
                        Console.WriteLine(e.Message);
                        LogError(e);
                    }
                    catch (DbEntityValidationException e)
                    {
                        Console.WriteLine(e.Message);
                        LogError(e);
                    }
                }
            }

            return RedirectToAction("Profiles", new { UserName = model.UserName });
        }

        public void CreateCommentHistory(Comment comment, string action)
        {
            CommentHistory history = new CommentHistory();
            history.Action = action;
            history.CommentID = comment.CommentID;
            history.Content = comment.Content;
            history.Time = comment.TimeEdited ?? comment.TimeCreated;

            db.CommentHistory.Add(history);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
                LogError(e);
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
                LogError(e);
            }
        }

        public ActionResult ArtistDetails(int artistID)
        {
            var artistResult = (from ar in db.Artist
                                   where ar.ArtistID == artistID
                                   select ar).FirstOrDefault();

            if (artistResult.IsAdminApproved == 1)
            {
                var albumResult = from al in db.Album
                                  join ar in db.Artist on al.ArtistID equals ar.ArtistID
                                  where al.ArtistID == artistID
                                  orderby al.ReleaseDate
                                  select al;

                List<Album> albumList = new List<Album>();
                foreach (var item in albumResult)
                {
                    if (item.IsAdminApproved == 1)
                        albumList.Add(item);
                }
                Artist artist = artistResult;

                ArtistDetailViewModel model = new ArtistDetailViewModel();
                model.Albums = albumList;
                model.Name = artist.Name;
                model.Description = artist.Description;
                model.Image = artist.Image;
                model.ActiveFrom = artist.ActiveFrom;
                model.ActiveUntil = artist.ActiveUntil;

                return View(model);
            }
            return Redirect("/");
        }

        public void LogError(Exception e)
        {
            String file = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Log\\log.txt";
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine("(" + DateTime.Now + "): " + e.Message + " Source: " + e.Source);
            sw.Close();
        }
    }
}