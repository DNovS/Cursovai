using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class SQLRepositoryDB : IRepositoryDB
    {
        private Appliances appliances;
        private SQLrepositoryTechnic sQLrepositoryTechnic;
        private SQLRepositoryState sQLRepositoryState;
        private SQLRepositoryPromoCode sQLRepositoryPromoCode;
        private SQLRepositoryOrder sQLRepositoryOrder;
        private SQLRepositoryLineOrder sQLRepositoryLineOrder;
        private SQLRepositoryClient sQLRepositoryClient;
        private SQLRepositoryCategory sQLRepositoryCategory;
        private SQLRepositoryReport qLRepositoryReport;
        public SQLRepositoryDB(Appliances appliances)
        {
            this.appliances = appliances;
        }

        public IRepository<Category> Categorys => sQLRepositoryCategory
                                                  ?? (sQLRepositoryCategory = new SQLRepositoryCategory(appliances));

        public IRepository<Client> Clients => sQLRepositoryClient
                                              ?? (sQLRepositoryClient = new SQLRepositoryClient(appliances));

        public IRepository<LineOrder> LineOreders => sQLRepositoryLineOrder
                                                     ?? (sQLRepositoryLineOrder = new SQLRepositoryLineOrder(appliances));

        public IRepository<Order> Orders => sQLRepositoryOrder
                                            ?? (sQLRepositoryOrder = new SQLRepositoryOrder(appliances));

        public IRepository<PromoCode> PromoCodes => sQLRepositoryPromoCode
                                                    ?? (sQLRepositoryPromoCode = new SQLRepositoryPromoCode(appliances));

        public IRepository<State> States => sQLRepositoryState
                                            ?? (sQLRepositoryState = new SQLRepositoryState(appliances));

        public IRepository<Technic> Technics => sQLrepositoryTechnic
                                                ?? (sQLrepositoryTechnic = new SQLrepositoryTechnic(appliances));

        public IRepositoryReport report => qLRepositoryReport
                                           ?? (qLRepositoryReport = new SQLRepositoryReport(appliances));

        public int Save()
        {
            return appliances.SaveChanges();
        }
    }
}
