using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL.Service
{
    public class ServiceOrder : Interfaces.IServiceOrder
    {
        private DAL.Interfaces.IRepositoryDB repositoryDB;
        public ServiceOrder(DAL.Interfaces.IRepositoryDB dB)
        {
            this.repositoryDB = dB;
        }
        public bool CreateOrder(Model.ModelOrder modelOrder)
        {
            DAL.Order order;
            
            if (modelOrder.id_order > 0)
            {
                order = repositoryDB.Orders.GetItem(modelOrder.id_order);
                order.cost = modelOrder.cost;
                order.id_state = modelOrder.id_state;
                order.id_code = modelOrder.id_code;
                order.id_client = modelOrder.id_client;
                order.LineOrder = new List<DAL.LineOrder>(modelOrder.lineOrders.Select(i => new DAL.LineOrder()
                {
                    id_technic = i.id_technic,
                    cost = i.cost,
                    quantity = i.quantity
                }).ToList());
                order.complition_date = modelOrder.registration_date.AddDays(2);     
                order.registration_date = modelOrder.registration_date;
            }
            else
            {
                modelOrder.id_order = repositoryDB.Orders.List.Last().id_order + 1;
                modelOrder.lineOrders.First().id_line = repositoryDB.LineOreders.List.Last().id_line + 1;
                for (int i = 1; i < modelOrder.lineOrders.Count; i++) modelOrder.lineOrders[i].id_line = modelOrder.lineOrders[i - 1].id_line + 1;
                order = new DAL.Order
                {
                    id_order = modelOrder.id_order,
                    cost = modelOrder.cost,
                    id_state = modelOrder.id_state,
                    id_code = modelOrder.id_code,
                    id_client = modelOrder.id_client,
                    LineOrder = new List<DAL.LineOrder>(modelOrder.lineOrders.Select(i => new DAL.LineOrder()
                    {
                        id_line = i.id_line,
                        id_order = i.id_order,
                        id_technic = i.id_technic,
                        cost = i.cost,
                        quantity = i.quantity
                    }).ToList()),
                    complition_date = modelOrder.registration_date.AddDays(2),
                    registration_date = modelOrder.registration_date,
                };
            }
            repositoryDB.Orders.Create(order);
            return repositoryDB.Save() > 0;
        }
        public Model.ModelOrder MakeOrder(Model.ModelOrder modelOrder)
        {
            
            decimal sum = 0;
            foreach (var id in modelOrder.lineOrders)
            {
                DAL.Technic technic = repositoryDB.Technics.GetItem(id.id_technic);
                if (technic == null)
                    throw new Exception("Техника не найдена");
                sum += id.cost;
            }
            return new Model.ModelOrder
            {
                cost = sum,
                id_state = 1,
                id_client = modelOrder.id_client,
                lineOrders = modelOrder.lineOrders,
                registration_date = DateTime.Now,
            };
        }
        public Model.ModelOrder Use_Code(Model.ModelOrder modelOrder, string code)
        {
            var g = repositoryDB.PromoCodes.List.Where(o => o.name == code && o.number_use > 0).FirstOrDefault();
            if (g != null)
            {
                modelOrder.cost = new Model.ModelPromoCode(g).Check(modelOrder.cost, repositoryDB);
                modelOrder.id_code = g.id_code;
            }
            return modelOrder;
        }
    }
}
