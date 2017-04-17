using KurtsMovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KurtsMovieRental.Services
{
    public class CustomerServices
    {

        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=MovieRentalDatabase;Trusted_Connection=True;";


        public IEnumerable<Customer> GetAllCustomers()
        {
            var rv = new List<Customer>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Customers;";

                var cmd = new SqlCommand(query, connection);

                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Customer(reader));
                }
                connection.Close();
            }
            return rv;
        }
    }
}