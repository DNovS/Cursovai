using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepositoryDB
    {
        IRepository<Category> Categorys { get; }
        IRepository<Client> Clients { get; }
        IRepository<LineOrder> LineOreders { get; }
        IRepository<Order> Orders { get; }
        IRepository<PromoCode> PromoCodes { get; }
        IRepository<State> States { get; }
        IRepository<Technic> Technics { get; }
        IRepositoryReport report { get; }
        int Save();
    }
}
