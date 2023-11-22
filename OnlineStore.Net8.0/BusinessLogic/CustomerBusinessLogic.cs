using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineStore.Net8._0
{
        public class CustomerBusinessLogic
    {
        //private readonly ICustomerRepository customerRepository;

        //public CustomerBusinessLogic(ICustomerRepository customerRepository)
        //{
        //    this.customerRepository = customerRepository;
        //}

        public void AddCustomer(CustomerModel customer)
        {

            try
            {
                ICustomerRepository customerRepository = new CustomerRepository();
                customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {

            }  

            //CustomerRepository customerRepository = new CustomerRepository();
            //customerRepository.AddCustomer(customer);
        }

        public void UpdateCustomer(int CustomerID, CustomerModel customer)
        {
            try
            {
                ICustomerRepository customerRepository = new CustomerRepository();
                customerRepository.UpdateCustomer(CustomerID, customer);
            }
            catch (Exception ex)
            {

            }  
        }

        public CustomerModel GetCustomer(int CustomerID)
        {
            try
            {
                ICustomerRepository customerRepository = new CustomerRepository();
                return customerRepository.GetCustomer(CustomerID);
            }
            catch (Exception ex)
            {
                 Console.WriteLine("An error occurred");
                 throw;
            }  
        }

        public LinkedList<CustomerModel> GetAllCustomers()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.GetAllCustomers();

        }

        public void DeleteCustomer(int CustomerID)
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            customerRepository.DeleteCustomer(CustomerID);
        }

    }
}