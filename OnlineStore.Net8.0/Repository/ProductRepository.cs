using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OnlineStore.Net8._0
{
    public class ProductRepository: IProductRepository
    {
        public void AddProduct(ProductModel product)
        {
            SqlConnection cnn;
            string connectionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                string query = ("INSERT INTO Product(Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@Name", product.Name);
                sqlcommand.Parameters.AddWithValue("@Price", product.Price);
                sqlcommand.Parameters.AddWithValue("@Quantity", product.Quantity);

                sqlcommand.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateProduct(int ProductID, ProductModel product)
        {
            SqlConnection cnn;
            string connectionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                string query = ("UPDATE Product SET Name=@Name, Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@Name", product.Name);
                sqlcommand.Parameters.AddWithValue("@Price", product.Price);
                sqlcommand.Parameters.AddWithValue("@Quantity", product.Quantity);
                sqlcommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                sqlcommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public ProductModel GetProduct(int ProductID)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("SELECT * from Product WHERE ProductID = @ProductID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@ProductID", ProductID);
                SqlDataReader reader = sqlcommand.ExecuteReader();

                ProductModel product1 = new ProductModel();

                while (reader.Read())
                {
                    string col1 = (string)reader["Name"];
                    int col2 = (int)reader["Price"];
                    int col3 = (int)reader["Quantity"];
                    int col4 = (int)reader["ProductID"];

                    product1.Name = col1;
                    product1.Price = col2;
                    product1.Quantity = col3;
                    product1.ProductID = col4;
                }
                cnn.Close();
                return product1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LinkedList<ProductModel> GetAllProducts()
        {
            LinkedList<ProductModel> list = new LinkedList<ProductModel>();

            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("SELECT * from Product");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    ProductModel product1 = new ProductModel();
                    string col1 = (string)reader["Name"];
                    int col2 = (int) reader["Price"];
                    int col3 = (int)reader["Quantity"];
                    int col4 = (int)reader["ProductID"];

                    product1.Name = col1;
                    product1.Price = col2;
                    product1.Quantity = col3;
                    product1.ProductID = col4;

                    list.AddLast(product1);
                }
                cnn.Close();
                return list;
            }

            catch (Exception ex)
            {
                return null;
            }

        }
        public void DeleteProduct(int ProductID)
        {
            SqlConnection cnn;
            string connetionString = "Data Source=HPPROBOOKG1\\SQLEXPRESS; Database=OnlineStore; Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string query = ("DELETE from Product WHERE ProductID = @ProductID");
                SqlCommand sqlcommand = new SqlCommand(query, cnn);
                sqlcommand.Parameters.AddWithValue("@ProductID", ProductID);
                sqlcommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}