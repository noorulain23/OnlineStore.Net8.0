using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineStore.Net8._0
{
    public class OrderController : ApiController
    {
        //private readonly ICustomerRepository customerRepository;

        //public CustomerController(ICustomerRepository customerRepository)
        //{
        //    this.customerRepository = customerRepository;
        //}
        //public CustomerController()
        //{
        //    // You might want to provide a default implementation for ICustomerRepository here
        //    // or leave it blank if it's not required.
        //}

        // POST: api/Order
        [HttpPost]
        [Route("order/add")]
        public IHttpActionResult AddOrder([FromBody]OrderModel Order)
        {
            if (ModelState.IsValid == false)
            {
                // error
                return BadRequest();
            }

            OrderBusinessLogic orderBuisnessLogic = new OrderBusinessLogic();
            orderBuisnessLogic.AddOrder(Order);

            return Created("", "");
        }

        // GET: api/Customer
        [HttpGet]
        [Route("order/get")]
        public IHttpActionResult Get()
        {
            //Customer customer1 = new Customer();
            //customer1.name = "aliza";
            //customer1.phoneNumber = "03183749236";
            //Customer customer2 = new Customer();
            //customer2.name = "sam";
            //customer2.phoneNumber = "031345349236";


            //LinkedList<Customer> list = new LinkedList<Customer>();
            //list.AddFirst(customer1);
            //list.AddLast(customer2);

            OrderBusinessLogic orderBusinessLogic = new OrderBusinessLogic();
            LinkedList<OrderModel> list = orderBusinessLogic.GetAllOrders();

            return Ok(list);
        }

        // GET: api/order/5        
        [HttpGet]
        [Route("order/get/{OrderID}")]
        public IHttpActionResult Get(int OrderID)
        {
            //Customer customer1 = new Customer();
            //customer1.name = "Ahmed";
            //customer1.phoneNumber = "03183749236";
            OrderBusinessLogic orderBusinessLogic = new OrderBusinessLogic();
            OrderModel order = orderBusinessLogic.GetOrder(OrderID);

            return Ok(order);
        }

        // DELETE: api/order/5
        [HttpDelete]
        [Route("order/delete/{OrderID}")]
        public IHttpActionResult Delete(int OrderID)
        {
            OrderBusinessLogic orderBusinessLogic = new OrderBusinessLogic();
            orderBusinessLogic.DeleteOrder(OrderID);
            return Ok();
        }

        //PUT:
        [HttpPut]
        [Route("update/order")]
        public IHttpActionResult Put([FromBody]OrderModel order)
        {
            //    if (ModelState.IsValid == false)
            //    {
            //        // error
            //        return BadRequest();
            //    }

            OrderBusinessLogic orderBusinessLogic = new OrderBusinessLogic();
            orderBusinessLogic.UpdateOrder(order);
            return Ok();
        }
    }
}