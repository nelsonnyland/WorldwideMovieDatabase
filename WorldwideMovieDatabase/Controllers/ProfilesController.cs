using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldwideMovieDatabase.Models;

namespace WorldwideMovieDatabase.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profiles
        public ActionResult Index()
        {
            return View(ProfileDb.GetAllProfiles(db));
        }

        // GET: Profiles/Details/5
        public ActionResult Profiles(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = ProfileDb.GetAllProfileMovieJobs(db, id.Value);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            ProfileMoviesJobsViewModel model = new ProfileMoviesJobsViewModel
            {
                AllMovies = MovieDb.GetAllMovies(db),
                AllJobs = JobDb.GetAllJobs(db)
            };
            return View(model);
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = 
        //    "ID,Name,BirthDate,DeathDate,Movies,Bio," +
        //    "ProfilePicture")] Profile profile)
        //public ActionResult Create([Bind(Include = "Profile,MovieJobs")] ProfileMovieJobsViewModel profileMovieVM)
        public ActionResult Create([Bind(Include = "Profile, MoviesToAdd, AllMovies, AllJobs")] ProfileMoviesJobsViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProfileDb.AddProfile(db, model.Profile, model.MoviesToAdd);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = ProfileDb.FindProfile(db, id.Value);
            if (profile == null)
            {
                return HttpNotFound();
            }

            ProfileMoviesJobsViewModel model = new ProfileMoviesJobsViewModel
            {
                Profile = profile,
                AllMovies = MovieDb.GetAllMovies(db),
                AllJobs = JobDb.GetAllJobs(db)
            };

            return View(model);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Profile, MoviesToAdd, AllMovies, AllJobs")] ProfileMoviesJobsViewModel model)
        {
            foreach (var value in ModelState.Values)
            {
                if (value.Errors.Count > 0)
                {
                    var list = value.Errors;
                }
            }
            if (ModelState.IsValid)
            {
                ProfileDb.UpdateProfile(db, model.Profile, model.MoviesToAdd);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = ProfileDb.FindProfile(db, id.Value);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = ProfileDb.FindProfile(db, id);
            ProfileDb.RemoveProfile(db, profile);
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
