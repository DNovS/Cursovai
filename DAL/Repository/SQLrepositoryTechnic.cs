using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLrepositoryTechnic : IRepository <Technic>
    {
        private readonly Appliances appliances;
        public SQLrepositoryTechnic(Appliances appliances) => this.appliances = appliances;

        public void Create(Technic item) => appliances.Technic.Add(item);

        public void Delete(int id)
        {
            Technic technic = appliances.Technic.Find(id);
            if (technic == null)
            {
                return;
            }
            appliances.Technic.Remove(technic);
        }

        public Technic GetItem(int id) => appliances.Technic.Find(id);

        public List<Technic> List => appliances.Technic.ToList();

        public void Update(Technic item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;
    }
}
