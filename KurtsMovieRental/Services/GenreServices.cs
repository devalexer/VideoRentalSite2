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

        //Displays One Genre Based on Id
        public Genre GetOneGenre(int id)
        {
            var genre = new Genre();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Genres WHERE ID = @id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    genre = new Genre(reader);
                }
                connection.Close();
            }
            return genre;
        }

        //Creates New Genre And Adds to Database
        public void CreateGenre(Genre genre)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Genres ([Name]) VALUES (@Name)";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Name", genre.Name);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Edits Existing Genre Through to Database
        public void EditGenre(Genre genre, int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE Genres SET [Name] = @Name WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Id", genre.Id);
                cmd.Parameters.AddWithValue("@Name", genre.Name);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteGenre(Genre genre)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var text = @"DELETE FROM Genres WHERE Id = @Id";

                var cmd = new SqlCommand(text, connection);
                cmd.Parameters.AddWithValue("@Id", genre.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}