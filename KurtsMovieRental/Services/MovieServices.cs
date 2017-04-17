using KurtsMovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KurtsMovieRental.Services
{
    public class MovieServices
    {
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalDatabase;Trusted_Connection=True;";


        public IEnumerable<Movie> GetAllMovies()
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

        //Displays One Movie Based on Id
        public Movie GetOneMovie(int id)
        {
            var movie = new Movie();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Movies WHERE ID = @id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movie = new Movie(reader);
                }
                connection.Close();
            }
            return movie;
        }

        //Creates New Movie And Adds to Database
        public void CreateMovie(Movie movie)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Movies ([Name], [YearReleased], [Director], " +
                    "[GenreId]) VALUES(@Name, @YearReleased, @Director, @GenreId)";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Name", movie.Name);
                cmd.Parameters.AddWithValue("@YearReleased", movie.YearReleased);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@GenreId", movie.GenreId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Edits Existing Movie Through to Database
        public void EditMovie(Movie movie, int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE Movies SET
                [Name] = @Name,
                [YearReleased] = @YearReleased
                ,[Director] = @Director
                ,[GenreId] = @GenreId
                WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id", movie.Id);
                cmd.Parameters.AddWithValue("@Name", movie.Name);
                cmd.Parameters.AddWithValue("@YearReleased", movie.YearReleased);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@GenreId", movie.GenreId);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteMovie(Movie movie)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var text = @"DELETE FROM Movies WHERE Id = @Id";

                var cmd = new SqlCommand(text, connection);
                cmd.Parameters.AddWithValue("@Id", movie.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


    }
}