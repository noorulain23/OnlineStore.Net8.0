using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineStore.Net8._0
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(OrderModel Order)
        {
            SqlConnection cnn;
            string connectionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                string query = ("INSERT INTO OrderTable(OrderNumber,CustomerID,ProductID) VALUES (@OrderNumber,@CustomerID,@ProductID)");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@OrderNumber", Order.OrderNumber);
                sqlcommand.Parameters.AddWithValue("@CustomerID", Order.CustomerID);
                sqlcommand.Parameters.AddWithValue("@ProductID", Order.ProductID);

                int rowsAffected = sqlcommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine( "Order placed successfully");
                }
                else
                {
                    Console.WriteLine("No rows affected. Order not placed.");
                }
                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateOrder(OrderModel Order)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("UPDATE OrderTable SET OrderNumber = @OrderNumber, CustomerID = @CustomerID,ProductID = @ProductID WHERE OrderID  = @OrderID ");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@OrderNumber", Order.OrderNumber);
                sqlcommand.Parameters.AddWithValue("@CustomerID", Order.CustomerID);
                sqlcommand.Parameters.AddWithValue("@ProductID", Order.ProductID);
                sqlcommand.Parameters.AddWithValue("@OrderID", Order.OrderID);
                sqlcommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public OrderModel GetOrder(int OrderID)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("SELECT * from OrderTable WHERE OrderID = @OrderID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@OrderID", OrderID);
                SqlDataReader reader = sqlcommand.ExecuteReader();

                OrderModel order = new OrderModel();

                while (reader.Read())
                {
                    int col1 = (int)reader["OrderNumber"];
                    int col2 = (int)reader["CustomerID"];
                    int col3 = (int)reader["ProductID"];
                    int col4 = (int)reader["OrderID"];

                    order.OrderNumber = col1;
                    order.CustomerID = col2;
                    order.ProductID = col3;
                    order.OrderID = col4;

                }
                cnn.Close();
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LinkedList<OrderModel> GetAllOrders()
        {
            LinkedList<OrderModel> list = new LinkedList<OrderModel>();

            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("SELECT * from OrderTable");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    int col1 = (int)reader["OrderNumber"];
                    int col2 = (int)reader["CustomerID"];
                    int col3 = (int)reader["ProductID"];
                    int col4 = (int)reader["OrderID"];

                    OrderModel order = new OrderModel();

                    order.OrderNumber = col1;
                    order.CustomerID = col2;
                    order.ProductID = col3;
                    order.OrderID = col4;

                    list.AddLast(order);
                }
                cnn.Close();
                return list;
            }

            catch (Exception ex)
            {
                return new LinkedList<OrderModel>();
            }

        }

        public void DeleteOrder(int OrderID)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("DELETE from OrderTable WHERE OrderID = @OrderID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@OrderID", OrderID);
                sqlcommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

    }
}