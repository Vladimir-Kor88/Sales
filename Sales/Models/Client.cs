using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } // название
        public string Contract { get; set; } // договор
        public DateTime DateContract { get; set; } // дата заключения договора
        public bool IsFree { get; set; } //бесплатник ли

        public List<Point> Points { get; set; } = new List<Point>(); //список точек
    }
}
