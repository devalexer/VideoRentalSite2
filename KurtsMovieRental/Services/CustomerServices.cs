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


        //Displays One Customer Based on Id
        public Customer GetOneCustomer(int id)
        {
            var customer = new Customer();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Customers WHERE ID = @id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer = new Customer(reader);
                }
                connection.Close();
            }
            return customer;
        }

        //Creates New Customer And Adds to Database
        public void CreateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Customers ([Name], [Email], [PhoneNumber])" +
                    "VALUES (@Name, @Email, @PhoneNumber)";

                var cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //Edits Existing Customer Through to Database
        public void EditCustomer(Customer customer, int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE Customers SET
                [Name] = @Name
                ,[Email] = @Email
                ,[PhoneNumber] = @PhoneNumber
                WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var text = @"DELETE FROM Customers WHERE Id = @Id";

                var cmd = new SqlCommand(text, connection);
                cmd.Parameters.AddWithValue("@Id", customer.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}