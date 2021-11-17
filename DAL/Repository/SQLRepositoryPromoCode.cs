using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryPromoCode : IRepository<PromoCode>
    {
        private readonly Appliances appliances;
        public SQLRepositoryPromoCode(Appliances appliances) => this.appliances = appliances;

        public void Create(PromoCode item) => appliances.PromoCode.Add(item);

        public void Delete(int id)
        {
            PromoCode promoCode = appliances.PromoCode.Find(id);
            if (promoCode == null)
            {
                return;
            }
            appliances.PromoCode.Remove(promoCode);
        }

        public PromoCode GetItem(int id) => appliances.PromoCode.Find(id);

        public List<PromoCode> List => appliances.PromoCode.ToList();

        public void Update(PromoCode item) => appliances.Entry(item).State = System.Data.Entity.EntityState.Modified;

    }
}
