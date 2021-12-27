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
    }
}
