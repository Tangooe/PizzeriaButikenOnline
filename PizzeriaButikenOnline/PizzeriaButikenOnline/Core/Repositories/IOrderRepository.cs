using System;
using System.Collections.Generic;
using PizzeriaButikenOnline.Core.Models;

namespace PizzeriaButikenOnline.Core.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        void Add(Order order);
        void Remove(Order order);
        Order GetActiveOrder(Guid token);
    }
}