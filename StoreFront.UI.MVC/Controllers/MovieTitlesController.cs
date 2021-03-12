using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;
using System.Drawing;
using StoreFront.UI.MVC.Utilities;
using PagedList;
using PagedList.Mvc;

namespace StoreFront.UI.MVC.Controllers
{
    public class MovieTitlesController : Controller
    {
        private MovieStoreEntities db = new MovieStoreEntities();

        // GET: MovieTitles
        public ActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 6;
            var movies = db.MovieTitles.OrderBy(m => m.MovieTitle1).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.MovieTitle1.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ViewBag.SearchString = searchString;

            return View(movies.ToPagedList(page, pageSize));
        }

        // GET: MovieTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieTitle movieTitle = db.MovieTitles.Find(id);
            if (movieTitle == null)
            {
                return HttpNotFound();
            }
            return View(movieTitle);
        }

        // GET: MovieTitles/Create
        public ActionResult Create()
        {
            ViewBag.AspectRatioID = new SelectList(db.AspectRatios, "AspectRatioID", "AspectRatio1");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1");
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Country1");
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName");
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Language1");
            ViewBag.MovieRatingID = new SelectList(db.MovieRatings, "MovieRatingID", "MovieRating1");
            ViewBag.StatusID = new SelectList(db.MovieStatus1, "StatusID", "Status");
            return View();
        }

        // POST: MovieTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieTitle1,GenreID,Price,UnitsInStock,ReleaseYear,MovieRatingID,Runtime,DirectorID,CountryID,AspectRatioID,IsColor,LanguageID,Description,Image,StatusID,CategoryID")] MovieTitle movieTitle, HttpPostedFileBase movieImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload Utility
                string imgName = "noImage.png";

                if (movieImage != null)
                {
                    imgName = movieImage.FileName;

                    string ext = imgName.Substring(imgName.LastIndexOf('.'));
                    string[] goodExts = { ".jpg", ".jpeg", ".gif", ".png" };
                    if (goodExts.Contains(ext.ToLower()) && (movieImage.ContentLength <= 4194304))
                    {
                        imgName = Guid.NewGuid() + ext.ToLower();
                        string savePath = Server.MapPath("~/Content/img/ProductImages/");
                        Image convertedImage = Image.FromStream(movieImage.InputStream);
                        int maxImageSize = 2000;
                        int maxThumbSize = 150;
                        ImageService.ResizeImage(savePath, imgName, convertedImage, maxImageSize, maxThumbSize);
                    }
                    else
                    {
                        imgName = "NoImage.png";
                    }
                }
                #endregion
                movieTitle.Image = imgName;

                db.MovieTitles.Add(movieTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspectRatioID = new SelectList(db.AspectRatios, "AspectRatioID", "AspectRatio1", movieTitle.AspectRatioID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1", movieTitle.CategoryID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Country1", movieTitle.CountryID);
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName", movieTitle.DirectorID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movieTitle.GenreID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Language1", movieTitle.LanguageID);
            ViewBag.MovieRatingID = new SelectList(db.MovieRatings, "MovieRatingID", "MovieRating1", movieTitle.MovieRatingID);
            ViewBag.StatusID = new SelectList(db.MovieStatus1, "StatusID", "Status", movieTitle.StatusID);
            return View(movieTitle);
        }

        // GET: MovieTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieTitle movieTitle = db.MovieTitles.Find(id);
            if (movieTitle == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspectRatioID = new SelectList(db.AspectRatios, "AspectRatioID", "AspectRatio1", movieTitle.AspectRatioID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1", movieTitle.CategoryID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Country1", movieTitle.CountryID);
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName", movieTitle.DirectorID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movieTitle.GenreID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Language1", movieTitle.LanguageID);
            ViewBag.MovieRatingID = new SelectList(db.MovieRatings, "MovieRatingID", "MovieRating1", movieTitle.MovieRatingID);
            ViewBag.StatusID = new SelectList(db.MovieStatus1, "StatusID", "Status", movieTitle.StatusID);
            return View(movieTitle);
        }

        // POST: MovieTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieTitle1,GenreID,Price,UnitsInStock,ReleaseYear,MovieRatingID,Runtime,DirectorID,CountryID,AspectRatioID,IsColor,LanguageID,Description,Image,StatusID,CategoryID")] MovieTitle movieTitle, HttpPostedFileBase movieImage)
        {
            if (ModelState.IsValid)
            {
                if (movieImage != null)
                {
                    string imgName = movieImage.FileName;
                    string ext = imgName.Substring(imgName.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".gif", ".png" };
                    if (goodExts.Contains(ext.ToLower()) && (movieImage.ContentLength <= 4194304))
                    {
                        imgName = Guid.NewGuid() + ext.ToLower();
                        string savePath = Server.MapPath("~/Content/img/ProductImages/");
                        Image convertedImage = Image.FromStream(movieImage.InputStream);
                        int maxImageSize = 2000;
                        int maxThumbSize = 150;
                        ImageService.ResizeImage(savePath, imgName, convertedImage, maxImageSize, maxThumbSize);

                        if (movieTitle.Image != null && movieTitle.Image != "NoImage.png")
                        {
                            string path = Server.MapPath("~/Content/img/ProductImages/");
                            ImageService.Delete(path, movieTitle.Image);
                        }

                        movieTitle.Image = imgName;
                    }
                }
                db.Entry(movieTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspectRatioID = new SelectList(db.AspectRatios, "AspectRatioID", "AspectRatio1", movieTitle.AspectRatioID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Category1", movieTitle.CategoryID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Country1", movieTitle.CountryID);
            ViewBag.DirectorID = new SelectList(db.Directors, "DirectorID", "FirstName", movieTitle.DirectorID);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", movieTitle.GenreID);
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Language1", movieTitle.LanguageID);
            ViewBag.MovieRatingID = new SelectList(db.MovieRatings, "MovieRatingID", "MovieRating1", movieTitle.MovieRatingID);
            ViewBag.StatusID = new SelectList(db.MovieStatus1, "StatusID", "Status", movieTitle.StatusID);
            return View(movieTitle);
        }

        // GET: MovieTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieTitle movieTitle = db.MovieTitles.Find(id);
            if (movieTitle == null)
            {
                return HttpNotFound();
            }
            return View(movieTitle);
        }

        // POST: MovieTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieTitle movieTitle = db.MovieTitles.Find(id);
            db.MovieTitles.Remove(movieTitle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
