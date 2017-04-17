using KurtsMovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KurtsMovieRental.Services
{
    public class RentalServices
    {
        //NEEDS WORK
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalDatabase;Trusted_Connection=True;";


        public IEnumerable<Movie> GetAllOverDueMovies()
        {
            var rv = new List<Movie>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Movies JOIN Genres ON Movies.GenreId = Genres.Id;";

                var cmd = new SqlCommand(query, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Movie(reader));
                }
                connection.Close();
            }
            return rv;
        }

    }
}