using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Net8._0
{
    public interface IProductRepository
    {
            ProductModel GetProduct(int ProductID);
            LinkedList<ProductModel> GetAllProducts();
            void UpdateProduct(int ProductID, ProductModel product);
            void AddProduct(ProductModel Product);
            void DeleteProduct(int ProductID);
        }
}
