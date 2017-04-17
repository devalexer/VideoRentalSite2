using KurtsMovieRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KurtsMovieRental.Controllers
{
    public class CustomerController : Controller
    {

        CustomerServices customerServices = new CustomerServices();


        public ActionResult Index()
        {
            var newCustomer = customerServices.GetAllCustomers();
            return View(newCustomer);
        }
    }
}
