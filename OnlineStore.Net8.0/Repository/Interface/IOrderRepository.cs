using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Net8._0
{
    public interface IOrderRepository
    {
        OrderModel GetOrder(int OrderID);
        LinkedList<OrderModel> GetAllOrders();
        void UpdateOrder(OrderModel Order);
        void AddOrder( OrderModel  Order);
        void DeleteOrder(int OrderID);
    }
}