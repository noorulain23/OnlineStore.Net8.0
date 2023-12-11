using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OnlineStore.Net8._0
{
    public class CustomerRepository : ICustomerRepository
    {
         public void AddCustomer(CustomerModel customer)
        {
            SqlConnection cnn;
            string connectionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connectionString); 
            try
            {
                cnn.Open();
                string query = ("INSERT INTO Customer(FirstName, LastName, PhoneNumber) VALUES (@FirstName, @LastName, @PhoneNumber)");
                SqlCommand sqlcommand = new SqlCommand(query,cnn);
                sqlcommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                sqlcommand.Parameters.AddWithValue("@LastName", customer.LastName);
                sqlcommand.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

                int rowsAffected = sqlcommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Customer added successfully.");
                }
                else
                {
                    Console.WriteLine("No rows affected. Customer not added.");
                }
                cnn.Close();
            }
            catch(Exception ex)
                {

                }     
        }

        public void UpdateCustomer(int CustomerID, CustomerModel customer)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("UPDATE Customer SET FirstName = @FirstName, LastName = @LastName,PhoneNumber = @PhoneNumber WHERE CustomerID  = @CustomerID ");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                sqlcommand.Parameters.AddWithValue("@LastName", customer.LastName);
                sqlcommand.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                sqlcommand.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                sqlcommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public CustomerModel GetCustomer(int CustomerID)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("SELECT * from Customer WHERE CustomerID = @CustomerID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                SqlDataReader reader = sqlcommand.ExecuteReader();

                CustomerModel customer1 = new CustomerModel();

                while (reader.Read())
                {
                    string col1 = (string)reader["FirstName"];
                    string col2 = (string)reader["LastName"];
                    string col3 = (string)reader["PhoneNumber"];
                    int col4 = (int)reader["CustomerID"];

                    customer1.FirstName = col1;
                    customer1.LastName = col2;
                    customer1.PhoneNumber = col3;
                    customer1.CustomerID = col4;
             
                }
                cnn.Close();
                return customer1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LinkedList<CustomerModel> GetAllCustomers()
        {
            LinkedList<CustomerModel> list = new LinkedList<CustomerModel>();

            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("SELECT * from Customer");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    string col1 = (string)reader["FirstName"];
                    string col2 = (string)reader["LastName"];
                    string col3 = (string)reader["PhoneNumber"];
                    int col4 = (int)reader["CustomerID"];

                    CustomerModel customer1 = new CustomerModel();
                    customer1.FirstName = col1;
                    customer1.LastName = col2;
                    customer1.PhoneNumber = col3;
                    customer1.CustomerID = col4;
             

                    list.AddLast(customer1);
                }
                cnn.Close();
                return list;
            }

            catch (Exception ex)
            {
                return new LinkedList<CustomerModel>();
            }

        }

        public void DeleteCustomer(int CustomerID)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("DELETE from Customer WHERE CustomerID = @CustomerID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                sqlcommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
