using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FollowUp.Controllers
{
    [AllowAnonymous]//iedereen mag homepage zien ondanks filter in filterconfig
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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Navbar()
        {
            var model = new NavBarViewModel()
                {
                    User = User.IsInRole("User"),
                    Manager = User.IsInRole("Manager"),
                    Dispatcher = User.IsInRole("Dispatcher"),
                    Solver = User.IsInRole("Solver"),
                    Administrator = User.IsInRole("Administrator")
                }
                ;
            return PartialView( model);
        }

    }

    public class NavBarViewModel
    {
        public bool User { get; set; }
        public bool Manager { get; set; }
        public bool Solver { get; set; }
        public bool Dispatcher { get; set; }
        public bool Administrator { get; set; }
    }
}