using KurtsMovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KurtsMovieRental.Services
{
    public class GenreServices
    {

        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalDatabase;Trusted_Connection=True;";


        public IEnumerable<Genre> GetAllGenres()
        {
            var rv = new List<Genre>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var text = @"SELECT * FROM Genres;";
                var cmd = new SqlCommand(text, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Genre(reader));
                }
                connection.Close();
            }
            return rv;
        }

        //EDIT
        //DELETE
    }
}