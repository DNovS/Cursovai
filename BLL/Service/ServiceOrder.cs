using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BLL.Service
{
    public class ServiceOrder : BLL.Interfaces.IServiceOrder
    {
        private DAL.Interfaces.IRepositoryDB repositoryDB;
        public ServiceOrder(DAL.Interfaces.IRepositoryDB dB)
        {
            this.repositoryDB = dB;
        }
        public bool CreateOrder(BLL.Model.ModelOrder order, string code)
        {
            List<DAL.LineOrder> lineOrders = new List<DAL.LineOrder>();
            decimal sum = 0;
            int i = 0;
            foreach (var id in order.line)
            {
                DAL.Technic technic = repositoryDB.Technics.GetItem(id);
                if (technic == null)
                    throw new Exception("Техника не найдена");
                lineOrders.Add(new DAL.LineOrder
                {
                    id_order = order.id_order,
                    id_technic = technic.id_technic,
                    cost = technic.cost * order.quant[i],
                    quantity = order.quant[i],
                });
                sum += lineOrders[i].cost;
                i++;
            }
            var g = repositoryDB.PromoCodes.List.Where(o => o.name == code && o.number_use > 0).FirstOrDefault();
            if (g != null) sum = new Model.ModelPromoCode(g).Check(sum);
            DAL.Order order1;
            if (order.id_order > 0)
            {
                order1 = repositoryDB.Orders.GetItem(order.id_order);
                order1.cost = sum;
                order1.id_state = order.id_state;
                order1.id_code = g.id_code;
                order1.id_client = order.id_client;
                order1.LineOrder = lineOrders;
                order1.registration_date = DateTime.Now;
            }
            else
            {
                order1 = new DAL.Order
                {
                    cost = sum,
                    id_state = order.id_state,
                    id_code = g.id_code,
                    id_client=order.id_client,
                    LineOrder = lineOrders,
                    registration_date = DateTime.Now,
                };
            }
            repositoryDB.Orders.Create(order1);
            lineOrders.ForEach(q => repositoryDB.LineOreders.Create(new DAL.LineOrder
            {
                id_order = q.id_order,
                id_technic = q.id_technic,
                cost = q.cost,
                quantity = q.quantity,
            }));
            return repositoryDB.Save() > 0;
        }
    }
}
