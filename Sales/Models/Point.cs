using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Point
    {
        public int Id { get; set; }
        public string Address { get; set; } // адрес точки

        // клиент, к которому принадлежит точка
        public int ClientId { get; set; } 
        public Client Client { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>(); //список точек
    }
}
