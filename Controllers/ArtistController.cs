using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SetifyFinal.Models;

namespace SetifyFinal.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Random()
        {
            var artist = new Artist() {Name = "Radiohead"};

            //View dictionary and pass artist to view.
            ViewData["Artist"] = artist;

            //Other  Action results can include...
            //return Content ("Hello World");
            //return HttpNotFound();
            //return RedirectToAction
            return View();
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //Artists
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //Check to see if there is a value
            if (!pageIndex.HasValue)
                pageIndex = 1;

            //Sort by Name
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            //Page equals first and second parameter
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseMonth(int year, int month)
        {
            //Returns the pathing of year and month
            return Content(year + "/" + month);
        }
    }
}
