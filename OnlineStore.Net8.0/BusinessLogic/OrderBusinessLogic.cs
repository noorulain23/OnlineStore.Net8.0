using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineStore.Net8._0
{
    public class OrderBusinessLogic
    {
        public void AddOrder(OrderModel Order)
        {
            try
            {
                IOrderRepository OrderRepository = new OrderRepository();
                OrderRepository.AddOrder(Order);
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateOrder(OrderModel order)
        {
            try
            {
                IOrderRepository orderRepository = new OrderRepository();
                orderRepository.UpdateOrder(order);
            }
            catch (Exception ex)
            {

            }
        }

        public OrderModel GetOrder(int OrderID)
        {
            try
            {
                IOrderRepository OrderRepository = new OrderRepository();
                return OrderRepository.GetOrder(OrderID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                throw;
            }
        }

        public LinkedList<OrderModel> GetAllOrders()
        {
            IOrderRepository OrderRepository = new OrderRepository();
            return OrderRepository.GetAllOrders();
        }

        public void DeleteOrder(int OrderID)
        {

            IOrderRepository OrderRepository = new OrderRepository();
            OrderRepository.DeleteOrder(OrderID);
        }

    }
}