using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Sales.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sales.Controllers
{
    public class HomeController : Controller
    {
        DataContext db;
        public HomeController(DataContext context)
        {
            this.db = context;
            if (db.Clients.Count() == 0)
            {
                Client intel = new Client { Name = "Intel", Contract = "Ghtffuy", IsFree = false, DateContract = new DateTime(2019, 8, 21) };
                Client dell = new Client { Name = "Dell", Contract = "Ghjhjk", IsFree = true, DateContract = new DateTime(2020, 9, 1) };

                Point moscow = new Point { Address = "Moscow", Client = intel };
                Point krasnodar = new Point { Address = "Krasnodar", Client = intel };

                Order first = new Order { dateOrder = new DateTime(2020, 9, 30), Sum = 32.45f, Point = moscow };
                Order second = new Order { dateOrder = new DateTime(2020, 10, 16), Sum = 21.09f, Point = moscow };

                db.Clients.AddRange(intel, dell);
                db.Points.AddRange(moscow, krasnodar);
                db.Orders.AddRange(first, second);
                db.SaveChanges();
            }
        }
        public IActionResult Index(int? client, int? point, string name,
                                DateTime? dateBeginSale, DateTime? dateEndSale,
                                DateTime? dateBeginContract, DateTime? dateEndContract,
                                int isFree = 1, SortState sortOrder = SortState.IsFreeAsc)
        {
            IQueryable<Order> orderIQuer = db.Orders;
            IQueryable<Point> pointIQuer = db.Points;
            IQueryable<Client> clientIQuer = db.Clients;

            if (dateBeginSale != null)
                orderIQuer = orderIQuer.Where(o => o.dateOrder >= dateBeginSale);

            if (dateEndSale != null)
                orderIQuer = orderIQuer.Where(o => o.dateOrder <= dateEndSale);

            if (point != null)
                orderIQuer = orderIQuer.Where(o => o.PointId == point);

            var groupsOrdersByPoint = orderIQuer.GroupBy(x => x.PointId, x => x.Sum)
                                                .Select(g => new { PointId = g.Key, PointOrders = g.Count(), PointSum = g.Sum() });

            if (client != null)
                pointIQuer = pointIQuer.Where(p => p.ClientId == client);

            if (dateBeginContract != null)
                clientIQuer = clientIQuer.Where(c => c.DateContract >= dateBeginContract);

            if (dateEndContract != null)
                clientIQuer = clientIQuer.Where(c => c.DateContract <= dateEndContract);

            if (name != null)
                clientIQuer = clientIQuer.Where(c => c.Name.Contains(name));

            if (isFree > 1)
            {
                if (isFree == 2)
                     clientIQuer = clientIQuer.Where(c => !c.IsFree);
                else
                     clientIQuer = clientIQuer.Where(c => c.IsFree);
            }

            IQueryable<GroupPoint> GP = from gp in groupsOrdersByPoint
                                        join p in pointIQuer on gp.PointId equals p.Id
                                        join c in clientIQuer on p.ClientId equals c.Id
                                        select new GroupPoint
                                        {
                                            IsFree = c.IsFree,
                                            ClientId = c.Id,
                                            Address = p.Address,
                                            Name = c.Name,
                                            Contract = c.Contract,
                                            PointId = p.Id,
                                            DateContract = c.DateContract,
                                            PointOrders = gp.PointOrders,
                                            PointSum = gp.PointSum
                                        };
            switch (sortOrder)
            {
                case SortState.IsFreeAsc:
                    GP = GP.OrderBy(s => s.IsFree);
                    break;
                case SortState.IsFreeDesc:
                    GP = GP.OrderByDescending(s => s.IsFree);
                    break;
                case SortState.IdClientAsc:
                    GP = GP.OrderBy(s => s.ClientId);
                    break;
                case SortState.IdClientDesc:
                    GP = GP.OrderByDescending(s => s.ClientId);
                    break;
                case SortState.IdPointAsc:
                    GP = GP.OrderBy(s => s.PointId);
                    break;
                case SortState.IdPointDesc:
                    GP = GP.OrderByDescending(s => s.PointId);
                    break;
                case SortState.NameAsc:
                    GP = GP.OrderBy(s => s.Name);
                    break;
                case SortState.NameDesc:
                    GP = GP.OrderByDescending(s => s.Name);
                    break;
                case SortState.AddressAsc:
                    GP = GP.OrderBy(s => s.Address);
                    break;
                case SortState.AddressDesc:
                    GP = GP.OrderByDescending(s => s.Address);
                    break;
                case SortState.ContractAsc:
                    GP = GP.OrderBy(s => s.Contract);
                    break;
                case SortState.ContractDesc:
                    GP = GP.OrderByDescending(s => s.Contract);
                    break;
                case SortState.DateContractAsc:
                    GP = GP.OrderBy(s => s.DateContract);
                    break;
                case SortState.DateContractDesc:
                    GP = GP.OrderByDescending(s => s.DateContract);
                    break;
                case SortState.NumbPointOrdersAsc:
                    GP = GP.OrderBy(s => s.PointOrders);
                    break;
                case SortState.NumbPointOrdersDesc:
                    GP = GP.OrderByDescending(s => s.PointOrders);
                    break;
                case SortState.SumPointAsc:
                    GP = GP.OrderBy(s => s.PointSum);
                    break;
                case SortState.SumPointDesc:
                    GP = GP.OrderByDescending(s => s.PointSum);
                    break;
            }

            var listGroupPoints = GP.ToList();
            var fvm = new FilterViewModel(client, point, name, dateBeginSale, dateEndSale, dateBeginContract, dateEndContract, isFree);
            var svm = new SortViewModel(sortOrder);
            var ivm = new IndexViewModel
            {
                ViewGroupPoints = listGroupPoints,
                FilterViewModel = fvm,
                SortViewModel = svm
            };
            return View(ivm);
        }
    }
}
