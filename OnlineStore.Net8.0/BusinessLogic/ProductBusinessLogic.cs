using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace OnlineStore.Net8._0
{
	public class ProductBusinessLogic
	{
        public void AddProduct(ProductModel product)
        {
            try
        {
            IProductRepository productRepository = new ProductRepository();
            productRepository.AddProduct(product);
        }
         catch (Exception ex)
         {

         }
        }

        public void UpdateProduct(int ProductID, ProductModel product)
        {
            try
            {
                IProductRepository productRepository = new ProductRepository();
                productRepository.UpdateProduct(ProductID, product);
            }
            catch(Exception ex)
            {

            }
        }

        public ProductModel GetProduct(int ProductID)
        {
            try
            {
                IProductRepository productRepository = new ProductRepository();
                return productRepository.GetProduct(ProductID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                throw;
            }
        }

         public LinkedList<ProductModel> GetAllProducts()
         {
                IProductRepository productRepository = new ProductRepository();
                return productRepository.GetAllProducts();
         }

         public void DeleteProduct(int ProductID)
         {

             IProductRepository productRepository = new ProductRepository();
             productRepository.DeleteProduct(ProductID);
         }

      }
}