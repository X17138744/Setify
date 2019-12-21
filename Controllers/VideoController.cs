using System.IO;
using System.Web.Mvc;

namespace SetifyFinal.Controllers
{
    public class VideoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetVideo()
        {
            var videoPath =
                Request.MapPath("~/Content/music.mp4");
            FileStream fs =
                new FileStream(videoPath, FileMode.Open);
            return new FileStreamResult(fs, "video/mp4");
        }
    }
}
