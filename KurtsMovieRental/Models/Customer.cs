using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurtsMovieRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public Customer() { }


        public Customer(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"].ToString();
            this.Email = reader["Email"].ToString();
            this.PhoneNumber = reader["PhoneNumber"].ToString();
        }


        public Customer(FormCollection collection)
        {
            this.Id = int.Parse(collection["Id"]);
            this.Name = collection["Name"].ToString();
            this.Email = collection["Email"].ToString();
            this.PhoneNumber = collection["PhoneNumber"].ToString();
        }
    }
}