using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace OnlineStore.Net8._0
{
    public class CustomerModel
    {
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string PhoneNumber{ get; set; }
        public int CustomerID { get; set; }
    }
}