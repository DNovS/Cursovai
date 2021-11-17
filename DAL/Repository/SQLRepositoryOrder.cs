using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryOrder : IRepository<Order>
    {
        private readonly Appliances appliances;
        public SQLRepositoryOrder(Appliances appliances) => this.appliances = appliances;

        public void Create(Order item) => appliances.Order.Add(item);

        public void Delete(int id)
        {
            Order order = appliances.Order.Find(id);
            if (order == null)
            {
                return;
            }
            appliances.Order.Remove(order);
        }

        public Order GetItem(int id) => appliances.Order.Find(id);

        public List<Order> List => appliances.Order.ToList();

        public void Update(Order item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;
    }
}
