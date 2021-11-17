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
                order.LineOrder = modelOrder.lineOrders;
                order.registration_date = modelOrder.registration_date;
            }
            else
            {
                order = new DAL.Order
                {
                    cost = modelOrder.cost,
                    id_state = modelOrder.id_state,
                    id_code = modelOrder.id_code,
                    id_client = modelOrder.id_client,
                    LineOrder = modelOrder.lineOrders,
                    registration_date = modelOrder.registration_date,
                };
            }
            repositoryDB.Orders.Create(order);
            return repositoryDB.Save() > 0;
        }
        public Model.ModelOrder MakeOrder(Model.ModelOrder modelOrder)
        {
            List<DAL.LineOrder> lineOrders = new List<DAL.LineOrder>();
            decimal sum = 0;
            int i = 0;
            foreach (var id in modelOrder.line)
            {
                DAL.Technic technic = repositoryDB.Technics.GetItem(id);
                if (technic == null)
                    throw new Exception("Техника не найдена");
                lineOrders.Add(new DAL.LineOrder
                {
                    id_order = modelOrder.id_order,
                    id_technic = technic.id_technic,
                    cost = technic.cost * modelOrder.quant[i],
                    quantity = modelOrder.quant[i],
                });
                sum += lineOrders[i].cost;
                i++;
            }
            return new Model.ModelOrder
            {
                cost = sum,
                id_state = modelOrder.id_state,
                id_client = modelOrder.id_client,
                lineOrders = lineOrders,
                registration_date = DateTime.Now,
            };
        }
        public Model.ModelOrder Use_Code(Model.ModelOrder modelOrder, string code)
        {
            var g = repositoryDB.PromoCodes.List.Where(o => o.name == code && o.number_use > 0).FirstOrDefault();
            if (g != null) modelOrder.cost = new Model.ModelPromoCode(g).Check(modelOrder.cost);
            return modelOrder;
        }
    }
}
