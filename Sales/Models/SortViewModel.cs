using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class SortViewModel
    {
        public SortViewModel(SortState sortOrder)
        {
            IsFreeSort = sortOrder == SortState.IsFreeAsc ? SortState.IsFreeDesc : SortState.IsFreeAsc;
            IdClientSort = sortOrder == SortState.IdClientAsc ? SortState.IdClientDesc : SortState.IdClientAsc;
            IdPointSort = sortOrder == SortState.IdPointAsc ? SortState.IdPointDesc : SortState.IdPointAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AddressSort = sortOrder == SortState.AddressAsc ? SortState.AddressDesc : SortState.AddressAsc;
            ContractSort = sortOrder == SortState.ContractAsc ? SortState.ContractDesc : SortState.ContractAsc;
            DateContractSort = sortOrder == SortState.DateContractAsc ? SortState.DateContractDesc : SortState.DateContractAsc;
            NumbPointOrdersSort = sortOrder == SortState.NumbPointOrdersAsc ? SortState.NumbPointOrdersDesc : SortState.NumbPointOrdersAsc;
            SumPointSort = sortOrder == SortState.SumPointAsc ? SortState.SumPointDesc : SortState.SumPointAsc;
        }

        public SortState IsFreeSort { get; private set; } // значение для сортировки по статусу
        public SortState IdClientSort { get; private set; }    // значение для сортировки по ID клиента
        public SortState IdPointSort { get; private set; }   //значение для сортировки по ID точки
        public SortState NameSort { get; private set; } // значение для сортировки по названию клиента
        public SortState AddressSort { get; private set; }    // значение для сортировки по адресу точки
        public SortState ContractSort { get; private set; }    // значение для сортировки по договору
        public SortState DateContractSort { get; private set; }   //значение для сортировки по дате договора
        public SortState NumbPointOrdersSort { get; private set; } // значение для сортировки по заказам точки
        public SortState SumPointSort { get; private set; }    // значение для сортировки по сумме точки
    }
}
