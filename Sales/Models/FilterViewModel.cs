using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class FilterViewModel
    {
        public FilterViewModel (int? client, int? point, string name, 
                                DateTime? dateBeginSale, DateTime? dateEndSale,
                                DateTime? dateBeginContract, DateTime? dateEndContract,
                                int isFree)
        {
            Client = client;
            Point = point;
            Name = name;
            DateBeginSale = dateBeginSale == null ? null : ((DateTime)dateBeginSale).ToString("yyyy-MM-dd");
            DateEndSale = dateEndSale == null ? null : ((DateTime)dateEndSale).ToString("yyyy-MM-dd");
            DateBeginContract = dateBeginContract == null ? null : ((DateTime)dateBeginContract).ToString("yyyy-MM-dd");
            DateEndContract = dateEndContract == null ? null : ((DateTime)dateEndContract).ToString("yyyy-MM-dd");
            IsFree = isFree;
        }
        public int? Client { get; private set; }
        public int? Point { get; private set; }
        public string Name { get; private set; }
        public string DateBeginSale { get; private set; }
        public string DateEndSale { get; private set; }
        public string DateBeginContract { get; private set; }
        public string DateEndContract { get; private set; }
        public int IsFree { get; private set; }
    }
}
