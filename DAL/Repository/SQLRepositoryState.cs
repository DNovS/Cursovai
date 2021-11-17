using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryState : IRepository<State>
    {
        private readonly Appliances appliances;
        public SQLRepositoryState(Appliances appliances) => this.appliances = appliances;

        public void Create(State item) => appliances.State.Add(item);

        public void Delete(int id)
        {
            State state = appliances.State.Find(id);
            if (state == null)
            {
                return;
            }
            appliances.State.Remove(state);
        }

        public State GetItem(int id) => appliances.State.Find(id);

        public List<State> List => appliances.State.ToList();

        public void Update(State item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;
    }
}
