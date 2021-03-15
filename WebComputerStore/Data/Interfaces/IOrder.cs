using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebComputerStore.Models;

namespace WebComputerStore.Data.Interfaces
{
    public interface IOrder
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
