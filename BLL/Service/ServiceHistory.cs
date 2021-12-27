using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Model;

namespace BLL.Service
{
    public class ServiceHistory : BLL.Interfaces.IServiceHistory
    {
        DAL.Interfaces.IRepositoryDB repositoryDB;
        public ServiceHistory(DAL.Interfaces.IRepositoryDB dB)
        {
            this.repositoryDB = dB;
        }
        public List<ModelOrder> orders() => repositoryDB.Orders.List.Select(i => new ModelOrder(i)).ToList();
        public List<ModelTechnic> technics(ModelOrder order) => repositoryDB.LineOreders.List.Where(i => i.id_order == order.id_order).Select(i => new ModelTechnic(i.Technic)).ToList();
        public void cancel(ModelOrder order)
        {
            repositoryDB.Orders.GetItem(order.id_order).id_state = 3;
            repositoryDB.Save();
        }
    }
}
