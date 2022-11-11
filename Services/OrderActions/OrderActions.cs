using BAL.Models;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderActions
{
    public class OrderActions : IOrderActions
    {
        private MaravilContext orderContext;
        public OrderActions(MaravilContext context)
        {
            orderContext = context;
        }
        public bool CreateOrder(Order order)
        {
            order.CreatedOn = DateTime.Now;
            order.ModifiedOn = DateTime.Now;
            orderContext.Add(order);
            return orderContext.SaveChanges() > 0;
        }

        public bool DeleteOrder(List<Int64> orderIds)
        {
            bool result = false;
            List< Order> ordersToDelete = GetOrdersByIds(orderIds);
            if (ordersToDelete != null)
            {
                orderContext.RemoveRange(ordersToDelete);
                orderContext.SaveChanges();
                result = true;
            }
            else
            {
                throw new Exception("Orden de compra no encontrado");
            }
            return result;
        }     

        public Order GetOrderById(Int64 id)
        {
            return orderContext.Orders.FirstOrDefault(x => x.Id == id);
        } 

        public List<Order> GetOrdersByIds(List<Int64> ids)
        {
            return orderContext.Orders.Where(x =>   ids.Contains(x.Id)).ToList();
        }

        public List<Order> GetOrdersByListIds(List<long> orderIds)
        {
            List<Order> orders = orderContext.Set<Order>()
                                                 .Include(x => x.Client)
                                                 .Include(x => x.Client.Town)
                                                 .Include(x => x.Client.Town.State)
                                                 .Where(x => orderIds.Contains(x.Id))
                                                 .ToList(); 
            return orders;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <param name="clientId">Client</param>
        /// <param name="orderState">
        /// 1 - pending to deliver
        /// 2 - Delivered
        /// 0 - All orders
        /// </param>
        /// <returns></returns>
        public List<Order> ListOrder(Int64 clientId = 0, int orderState = 0)
        {

            List<Order> orders = orderContext.Set<Order>()
                                                  .Include(x => x.Client)
                                                  .Include(x => x.Client.Town)
                                                  .Include(x => x.Client.Town.State)
                                                  .ToList();
            if (clientId > 0)
            {
                orders = orders.Where(x => x.ClientId == clientId).ToList();
            }

            switch (orderState)
            {
                case 1://pending to deliver
                    orders = orderContext.Orders.Where(x => !x.IsDelivered).ToList();
                    break;
                case 2: //Delivered
                    orders = orderContext.Orders.Where(x => x.IsDelivered).ToList();
                    break;
                default://All orders
                    orders = orderContext.Orders.ToList();
                    break;
            }
            return orders;
        }

        public void MarkOrdersAsDelivered(List<Order> orders)
        {
            orders.ForEach(x => x.IsDelivered = true);
            orderContext.Orders.UpdateRange(orders);
            orderContext.SaveChanges();
        }

        public bool UpdateOrder(Order order)
        {
            bool result = false;
            if (order != null)
            {
                order.ModifiedOn = DateTime.Now;
                orderContext.Orders.Update(order);
                orderContext.SaveChanges();
                result = true;
            }
            else
            {
                throw new Exception("Orden de compra no encontrada");
            }
            return result;
        }
    }
}
