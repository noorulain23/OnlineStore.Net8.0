using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace OnlineStore.Net8._0
{
    public class CustomerController : ApiController    {
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

        // POST: api/Customer
        [HttpPost]
        [Route("customer/add")]
        public IHttpActionResult AddCustomer([FromBody]CustomerModel customer)
        {
            if (ModelState.IsValid == false)
            {
                // error
                return BadRequest();
            }

            CustomerBusinessLogic customerBuisnessLogic = new CustomerBusinessLogic();
            customerBuisnessLogic.AddCustomer(customer);

            return Created("", "");
        }

        // GET: api/Customer
        [HttpGet]
        [Route("customer/get")]
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

            CustomerBusinessLogic customerBusinessLogic = new CustomerBusinessLogic();
            LinkedList<CustomerModel> list = customerBusinessLogic.GetAllCustomers();

            return Ok(list);
        }

        // GET: api/Customer/5        
        [HttpGet]
        [Route("customer/get/{CustomerID}")]
        public IHttpActionResult Get(int CustomerID)
        {
            //Customer customer1 = new Customer();
            //customer1.name = "Ahmed";
            //customer1.phoneNumber = "03183749236";
            CustomerBusinessLogic customerBusinessLogic = new CustomerBusinessLogic();
            CustomerModel customer1 = customerBusinessLogic.GetCustomer(CustomerID);

            return Ok(customer1);
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        [Route("customer/delete/{CustomerID}")]
        public IHttpActionResult Delete(int CustomerID)
        {
            CustomerBusinessLogic CustomerBusinessLogic = new CustomerBusinessLogic();
            CustomerBusinessLogic.DeleteCustomer(CustomerID);
            return Ok();
        }

        //PUT:
        [HttpPut]
        [Route("customer/update/{CustomerID}")]
        public IHttpActionResult Put(int CustomerID, [FromBody]CustomerModel customer)
        {
            //    if (ModelState.IsValid == false)
            //    {
            //        // error
            //        return BadRequest();
            //    }

            CustomerBusinessLogic customerBuisnessLogic = new CustomerBusinessLogic();
            customerBuisnessLogic.UpdateCustomer(CustomerID, customer);
            return Ok();
        }
    }

            
}
 