using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class GroupPoint
    {
        public bool IsFree { get; set; } //бесплатник ли
        public int ClientId { get; set; } //ID клиента
        public int PointId { get; set; } //ID точки
        public string Name { get; set; } // название клиента
        public string Address { get; set; } // адрес точки
        public string Contract { get; set; } // договор
        public DateTime DateContract { get; set; } // дата заключения
        public int PointOrders { get; set; } // заказы точки
        public float PointSum { get; set; } // сумма точки
    }
}
