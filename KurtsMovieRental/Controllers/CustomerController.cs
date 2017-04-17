using KurtsMovieRental.Models;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var newCustomer = new Customer(collection);
            customerServices.CreateCustomer(newCustomer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = new CustomerServices().GetOneCustomer(id);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            //gathers new data inputted
            var updatedCustomer = new Customer
            {
                Name = collection["Name"],
                Email = collection["Email"].ToString(),
                PhoneNumber = collection["PhoneNumber"].ToString(),
                Id = id
            };
            //then saves to database
            new CustomerServices().EditCustomer(updatedCustomer, id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = customerServices.GetAllCustomers().First(f => f.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            customerServices.DeleteCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}
