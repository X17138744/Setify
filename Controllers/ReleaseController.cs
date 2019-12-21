using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetifyFinal.Controllers
{
    public class ReleaseController : Controller
    {
        // GET: Release
        public ActionResult New()
        {
            return View();
        }
    }
}