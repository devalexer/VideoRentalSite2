using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurtsMovieRental.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Genre() { }


        public Genre(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"].ToString();
        }

        public Genre(FormCollection collection)
        {
            //this.Id = int.Parse(collection["Id"]);
            this.Name = collection["Name"].ToString();
        }

    }


}