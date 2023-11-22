using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Net8._0
{
    public interface ICustomerRepository
    {
        LinkedList<CustomerModel> GetAllCustomers();
 
        CustomerModel GetCustomer(int CustomerID);
        void UpdateCustomer(int CustomerID, CustomerModel customer);
        void AddCustomer(CustomerModel customer);
        void DeleteCustomer(int CustomerID);
  
    }
}