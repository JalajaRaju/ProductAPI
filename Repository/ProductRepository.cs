using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProductsWebAPI.Models;

namespace ProductsWebAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private SampleDBEntities1 db = new SampleDBEntities1();

        //public ProductRepository()
        //{
        //    this.db = new SampleDBEntities();
        //}

        public void AddProduct(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(short id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }

            
        }

        public Product GetProductByID(short id)
        {
            Product product = db.Products.Find(id);
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products;
        }

        public void UpdateProduct(short id, Product product)
        {
            db.Entry(product).State = EntityState.Modified;

             db.SaveChanges();
            
        }

       
        public bool ProductExists(short id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }

       
    }
}