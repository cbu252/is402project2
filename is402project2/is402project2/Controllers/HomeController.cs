using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace is402project2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            List<SelectListItem> subjectOpts = new List<SelectListItem>();

            subjectOpts.Add(new SelectListItem { Text = "(Subject)", Value = "0", Selected = true });
            subjectOpts.Add(new SelectListItem { Text = "Questions about programs", Value = "1" });
            subjectOpts.Add(new SelectListItem { Text = "Questions about volunteers", Value = "2" });
            subjectOpts.Add(new SelectListItem { Text = "Other questions", Value = "3" });

            ViewBag.Subjects = subjectOpts;

            return View();
        }
    }
}