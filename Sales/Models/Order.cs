using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float Sum { get; set; } //сумма
        public DateTime dateOrder { get; set; } //дата заказа

        // точка, к которой принадлежит заказ
        public int PointId { get; set; }
        public Point Point { get; set; }
    }
}
