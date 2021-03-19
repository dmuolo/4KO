using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;
using PagedList;
using PagedList.Mvc;

namespace StoreFront.UI.MVC.Controllers
{
    public class DirectorsController : Controller
    {
        private MovieStoreEntities db = new MovieStoreEntities();

        #region Ajax Operations

        //Any unused (replaced by ajax) actions below should be commented out or deleted entirely as they still will route to the old views. This can only be achieved by URL hacking (someone would have to go into url and enter publisher/edit etc. etc. to get to it). AKA make sure unused views aren't accessible

        #region Ajax Delete
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            //get the publisher from the database
            Director dir = db.Directors.Find(id);

            //remove the publisher from EF
            db.Directors.Remove(dir);

            //save the changes to the database
            db.SaveChanges();

            //create a message to send to the user as a JSON result
            var message = $"Deleted the following publisher from the database: {dir.FullName}";

            //return the jsonResult
            return Json(new
            {
                id = id,
                message = message

            });
        }

        #endregion

        #region AJAX Details
        [HttpGet]
        public PartialViewResult DirectorDetails(int id)
        {
            //retrieve the publisher by id
            Director dir = db.Directors.Find(id);

            //return the partial view WITH the publisher object
            return PartialView(dir);

            //for this view:
            //right click and add aprtial view
            //scaffold to details
            //Publisher - model
            //CHECK the PartialView Checkbox
        }
        #endregion

        #region AJAX Create
        //Add the publisher to the db via AJAX and return a result
        public JsonResult AjaxCreate(Director director)
        {
            //even though this is a json result, the VIEW is a partial view so that we can render it in the index (our div that we created)

            //hard code that each publisher will be active by default (no checkbox in the form)
            //any pub created using this ajax method will be set to IsActive = true;

            db.Directors.Add(director);
            db.SaveChanges();
            return Json(director);
        }

        #endregion

        #region AJAX Edit [GET]
        public PartialViewResult PublisherEdit(int id)
        {
            //retrieve the publisher and retrun to the view with data
            //populated for updates
            Director director = db.Directors.Find(id);
            return PartialView(director);
        }

        #endregion

        #region AJAX Edit [POST]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AjaxEdit(Director director)
        {
            db.Entry(director).State = EntityState.Modified;//telling it we're modifying rather than adding a new one
            db.SaveChanges();
            return Json(director);//what we use to translate to create our brand new role translated by data, and is what will overlay our new table row
        }
        #endregion

        #endregion

        public ActionResult Tiles()
        {
            return View(db.Directors.ToList());
        }

        // GET: Directors
        public ActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 15;
            var dirs = db.Directors.OrderBy(m => m.LastName).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                dirs = dirs.Where(m => m.FullName.ToLower().Contains(searchString.ToLower())).ToList();
            }

            ViewBag.SearchString = searchString;

            return View(dirs.ToPagedList(page, pageSize));
        }

        // GET: Directors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: Directors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectorID,FirstName,LastName")] Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(director);
        }

        // GET: Directors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectorID,FirstName,LastName")] Director director)
        {
            if (ModelState.IsValid)
            {
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(director);
        }

        // GET: Directors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Director director = db.Directors.Find(id);
            db.Directors.Remove(director);
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
