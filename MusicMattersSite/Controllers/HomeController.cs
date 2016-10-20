using Microsoft.AspNet.Identity;
using MusicMattersSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicMattersSite.Controllers
{
    public class HomeController : Controller
    {
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
                using (var db = new ApplicationDbContext())
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
                            commentList.Add(pc);
                        }

                        var artistsResult = from item in db.Artist
                                            join ranking in db.UserArtist
                                            on item.ArtistID equals ranking.ArtistID
                                            join u in db.AppUser
                                            on ranking.UserID equals u.Id
                                            where u.Id == user.Id
                                            orderby ranking.IsRanked descending, ranking.Ranking ascending
                                            select new { item.Name, ranking.Ranking };
                        List<ArtistRanking> artistList = new List<ArtistRanking>();
                        foreach (var item in artistsResult)
                        {
                            ArtistRanking ar = new ArtistRanking();
                            ar.Artist = item.Name;
                            ar.Ranking = item.Ranking ?? 0;
                            artistList.Add(ar);
                        }

                        model.UserID = user.Id;
                        model.UserName = user.UserName;
                        model.Email = user.Email;
                        model.Bio = profile.Bio;
                        model.ShowEmail = profile.ShowEmail;
                        model.BackgroundColor = profile.BackgroundColor;
                        model.Comments = commentList;
                        model.Artists = artistList;
                        return View(model);
                    }
                }
            }
            return Redirect("/");
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(ProfileViewModel model)
        {
            if (ModelState.IsValidField("AddedComment.Content"))
            {
                string sortKey = "";

                model.Comment.TimeCreated = DateTime.Now;
                model.Comment.UserAuthorID = User.Identity.GetUserId();
                model.Comment.UserRecipientID = model.UserID;

                using (var db = new ApplicationDbContext())
                {
                    db.Comment.Add(model.Comment);
                    db.SaveChanges();

                    

                    var prefixResult = from item in db.Comment
                                       where item.CommentID == model.Comment.ParentID
                                       select item.SortKey;
                    if (prefixResult.FirstOrDefault() != null)
                    {
                        sortKey = prefixResult.FirstOrDefault() + ".";
                    }

                    sortKey += model.Comment.CommentID.ToString("D4"); //Pads the string with 4 zeroes
                    model.Comment.SortKey = sortKey;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Profiles", new { UserName = model.UserName });
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditComment(ProfileViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                /*var commentResult = from item in db.Comment
                                    where item.CommentID == Request.RequestContext.HttpContext.*/
            }

                return RedirectToAction("Profiles", new { UserName = model.UserName });
        }

            /*public ActionResult ArtistDetails(string artistName)
            {
                using (var db = new ApplicationDbContext())
                {
                    var artistResult = from artist in db.Artist
                                       join album in db.Album on artist.ArtistID equals album.ArtistID
                                       join song in db.Song on album.AlbumID equals song.AlbumID
                                       where artist.Name == artistName && artist.IsAdminApproved == 1 && album.IsAdminApproved == 1 && song.IsAdminApproved == 1
                                       select new { artist, album, song };
                    List<Album> albumList = artistResult.ToList()
                    ArtistDetailViewModel model = new ArtistDetailViewModel();
                    model.Albums = artistResult

                }
            }*/
        }
}