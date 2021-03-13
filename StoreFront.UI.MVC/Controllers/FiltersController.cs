using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace StoreFront.UI.MVC.Controllers
{
    public class FiltersController : Controller
    {
        private MovieStoreEntities ctx = new MovieStoreEntities();

        // GET: Filters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieMVCPaging(string searchString, int page = 1)
        {
            int pageSize = 6;
            var movies = ctx.MovieTitles.OrderBy(m => m.MovieTitle1).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.MovieTitle1.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ViewBag.SearchString = searchString;

            return View(movies.ToPagedList(page, pageSize));
        }
    }
}