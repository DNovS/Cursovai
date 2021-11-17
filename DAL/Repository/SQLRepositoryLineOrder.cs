using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryLineOrder : IRepository<LineOrder>
    {
        private readonly Appliances appliances;
        public SQLRepositoryLineOrder(Appliances appliances) => this.appliances = appliances;

        public void Create(LineOrder item) => appliances.LineOrder.Add(item);

        public void Delete(int id)
        {
            LineOrder lineOrder  = appliances.LineOrder.Find(id);
            if (lineOrder == null)
            {
                return;
            }
            appliances.LineOrder.Remove(lineOrder);
        }

        public LineOrder GetItem(int id) => appliances.LineOrder.Find(id);

        public List<LineOrder> List => appliances.LineOrder.ToList();

        public void Update(LineOrder item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;
    }
}
