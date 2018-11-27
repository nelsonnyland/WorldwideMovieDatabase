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
            return View(db.Profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Profiles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = ProfileDb.FindProfile(id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            List<Movie> movies = MovieDb.GetProfileMovies(id);

            List<MovieJobViewModel> movieJobs = new List<MovieJobViewModel>();

            foreach (Movie currMovie in movies)
            {
                movieJobs.Add(new MovieJobViewModel()
                {
                    Movie = currMovie
                });
            }

            ProfileMovieJobsViewModel profileMovieJobsVM = new ProfileMovieJobsViewModel()
            {
                Profile = profile,
                MovieJobs = movieJobs
            };
            return View(profileMovieJobsVM);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = 
        //    "ID,Name,BirthDate,DeathDate,Movies,Bio," +
        //    "ProfilePicture")] Profile profile)
        public ActionResult Create([Bind(Include = "Profile,MovieJobs")] ProfileMovieJobsViewModel profileMovieVM)
        {
            if (ModelState.IsValid)
            {
                AddProfileWithMovies(profileMovieVM);
                return RedirectToAction("Index");
            }
            return View(profileMovieVM);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BirthDate,DeathDate,Bio,ProfilePicture")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
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
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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

        /// <summary>
        /// Processes data from the ProfileMovieViewModel and makes calls to add it to the database.
        /// An inputted profile with a collection of movies they worked in and job titles for each
        /// movie is entered.
        /// </summary>
        /// <param name="profileMovieViewModel"></param>
        public void AddProfileWithMovies(ProfileMovieJobsViewModel profileMovieViewModel)
        {
            // Add Profile
            Profile currProfile = profileMovieViewModel.Profile;
            ProfileDb.AddProfile(currProfile);

            //Add Movies
            var movies = new List<Movie>();
            foreach (var movieJob in profileMovieViewModel.MovieJobs)
            {
                movies.Add(movieJob.Movie);
            }
            MovieDb.AddMovies(movies);

            // Add MovieProfiles
            var movieProfiles = new List<MovieProfile>();
            foreach (var movieJob in profileMovieViewModel.MovieJobs)
            {
                // Add all job titles for each movie
                foreach (var jobTitle in movieJob.JobTitles)
                {
                    MovieProfile currMovieProfile = new MovieProfile
                    {
                        ProfileId = currProfile.ID,
                        MovieId = movieJob.Movie.ID,
                        JobTitle = jobTitle
                    };
                    movieProfiles.Add(currMovieProfile);
                }
            }
            MovieProfileDb.AddMovieProfiles(movieProfiles);
        }
    }
}
