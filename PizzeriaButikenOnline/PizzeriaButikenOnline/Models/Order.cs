using System;
using System.Collections.Generic;

namespace PizzeriaButikenOnline.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
        public string OrderToken { get; set; }
        public string UserId { get; set; }

        public ICollection<OrderDish> OrderDishes { get; set; }
    }
}
