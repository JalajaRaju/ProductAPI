using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductsWebAPI.Models;
using ProductsWebAPI.Repository;

namespace ProductsWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductRepository repository;

        

        //public ProductsController( IProductRepository repository)
        //{
        //    this.repository = repository;
        //}

        public ProductsController()
        {
            repository = new ProductRepository();
        }

        // GET: api/Products
        public void GetProducts()
        {
            repository.GetProducts();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(short id)
        {
            Product product = repository.GetProductByID(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(short id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

           

            try
            {
                repository.UpdateProduct(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddProduct(product);

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(short id)
        {
            Product product = repository.GetProductByID(id);
            
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                repository.DeleteProduct(id);
                return Ok(product);
            }

           
        }

       

        private bool ProductExists(short id)
        {
            return repository.ProductExists(id);
        }
    }
}