using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStore.Net8._0
{
    public class ProductController : ApiController
    {
        // POST: api/Product
        [HttpPost]
        [Route("product/add")]
        public IHttpActionResult AddProduct([FromBody]ProductModel product)
        {
            if (ModelState.IsValid == false)
            {
                // error
                return BadRequest();
            }

            ProductBusinessLogic productBusinessLogic = new ProductBusinessLogic();
            productBusinessLogic.AddProduct(product);

            return Created("", "");
        }

        [HttpGet]
        [Route("product/get/{ProductID}")]
        public IHttpActionResult Get(int ProductID)
        {
            ProductModel product1 = new ProductModel();
            ProductBusinessLogic productBusinessLogic = new ProductBusinessLogic();
            product1 = productBusinessLogic.GetProduct(ProductID);

            return Ok(product1);
        }

        [HttpGet]
        [Route("product/get")]
        public IHttpActionResult Get()
        {
            LinkedList<ProductModel> list = new LinkedList<ProductModel>();
            ProductBusinessLogic productBusinessLogic = new ProductBusinessLogic();
            list = productBusinessLogic.GetAllProducts();

            return Ok(list);
        }

        [HttpPut]
        [Route("product/update/{ProductID}")]
        public IHttpActionResult Put(int ProductID, [FromBody]ProductModel product)
        {
            ProductBusinessLogic productBusinessLogic = new ProductBusinessLogic();
            productBusinessLogic.UpdateProduct(ProductID, product);

            return Ok();
        }

        [HttpDelete]
        [Route("product/delete/{ProductID}")]
        public IHttpActionResult Delete(int ProductID)
        {
            ProductBusinessLogic productBusinessLogic = new ProductBusinessLogic();
            productBusinessLogic.DeleteProduct(ProductID);
            return Ok();
        }


    }
}