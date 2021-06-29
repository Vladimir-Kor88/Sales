using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public enum SortState
    {
        IsFreeAsc,    // статус по возрастанию
        IsFreeDesc,   // статус по убыванию
        IdClientAsc,  // ID клиента по возрастанию
        IdClientDesc,    // ID клиента по убыванию
        IdPointAsc, // ID точки по возрастанию
        IdPointDesc, // ID точки по убыванию
        NameAsc,    // название клиента по возрастанию
        NameDesc,   // название клиента по убыванию
        AddressAsc,  // адрес точки по возрастанию
        AddressDesc,    // адрес точки по убыванию
        ContractAsc, // договор по возрастанию
        ContractDesc, // договор по убыванию
        DateContractAsc,    // дата договора по возрастанию
        DateContractDesc,   // дата договора по убыванию
        NumbPointOrdersAsc,  // заказы точки по возрастанию
        NumbPointOrdersDesc,    // заказы точки по убыванию
        SumPointAsc, // сумма точки по возрастанию
        SumPointDesc // сумма точки по убыванию
    }
}
