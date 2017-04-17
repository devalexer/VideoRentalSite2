using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurtsMovieRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //RETURN
        public ActionResult Return()
        {
            return View();
        }

        //OVERDUE
        public ActionResult Overdue()
        {
            return View();
        }


    }
}