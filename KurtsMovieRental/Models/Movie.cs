using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurtsMovieRental.Models
{
    public class Movie
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearReleased { get; set; }
        public string Director { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }


        public Movie() { }


        public Movie(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"]?.ToString();
            this.YearReleased = reader["YearReleased"] as int?;
            this.Director = reader["Director"]?.ToString();
            this.GenreId = reader["GenreId"] as int?;
        }

        public Movie(FormCollection collection)
        {
            //this.Id = int.Parse(collection["Id"]);
            this.Name = collection["Name"].ToString();
            this.YearReleased = int.Parse(collection["YearReleased"]);
            this.Director = collection["Director"].ToString();
            this.GenreId = int.Parse(collection["GenreId"]);
        }
    }
}