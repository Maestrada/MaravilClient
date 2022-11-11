using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderActions
{
    public interface IOrderActions
    {
        public bool CreateOrder(Order order);
        public bool UpdateOrder(Order order);
        public bool DeleteOrder(List<Int64> orderIds);     
        public List<Order> GetOrdersByListIds(List<Int64> orderIds);     
        public Order GetOrderById(Int64 id);
        public List<Order> GetOrdersByIds(List<Int64> ids);
        public List<Order> ListOrder(Int64 clientId = 0, int orderState = 0);
        public void MarkOrdersAsDelivered(List<Order>orders);
    }
}
