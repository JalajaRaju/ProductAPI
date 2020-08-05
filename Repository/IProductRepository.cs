using ProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsWebAPI.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(short id);
        void AddProduct(Product product);
        void UpdateProduct(short id, Product product);
        void DeleteProduct(short id);
        bool ProductExists(short id);
    }
}