using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WebComputerStore.Data.Interfaces;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext context;
        public OrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }


        /*
            t when an Order object is read from the database, the collection associated with the Lines
            property should also be loaded along with each Product object associated with each collection object
         */
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
       .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
        public void DeleteProduct(Order p)
        {
            context.Remove(p);
            context.SaveChanges();
        }


    }
}
