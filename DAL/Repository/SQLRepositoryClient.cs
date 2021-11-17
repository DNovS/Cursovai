using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryClient:IRepository<Client>
    {
        private readonly Appliances appliances;
        public SQLRepositoryClient(Appliances appliances) => this.appliances = appliances;

        public void Create(Client item) => appliances.Client.Add(item);

        public void Delete(int id)
        {
            Client client = appliances.Client.Find(id);
            if (client == null)
            {
                return;
            }
            appliances.Client.Remove(client);
        }

        public Client GetItem(int id) => appliances.Client.Find(id);

        public List<Client> List => appliances.Client.ToList();

        public void Update(Client item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;
    }
}
