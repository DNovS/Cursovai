using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryCategory : IRepository<Category>
    {
        private readonly Appliances appliances;
        public SQLRepositoryCategory(Appliances appliances) => this.appliances = appliances;

        public void Create(Category item) => appliances.Category.Add(item);

        public void Delete(int id)
        {
            Category category = appliances.Category.Find(id);
            if (category == null)
            {
                return;
            }
            appliances.Category.Remove(category);
        }

        public Category GetItem(int id) => appliances.Category.Find(id);

        public List<Category> List => appliances.Category.ToList();

        public void Update(Category item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;
    }
}
