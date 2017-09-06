using PizzeriaButikenOnline.Core.Models;
using PizzeriaButikenOnline.Core.Repositories;
using PizzeriaButikenOnline.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaButikenOnline.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }

        public Order GetActiveOrder(Guid token)
        {
            return _context.Orders.FirstOrDefault(o => o.Active && o.OrderToken == token);
        }
    }
}
