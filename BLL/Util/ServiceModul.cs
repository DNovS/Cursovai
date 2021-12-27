using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace BLL.Util
{
    public class ServiceModul : NinjectModule
    {
        private string connection;
        public ServiceModul(string connect) 
        {
            this.connection = connect;
        }
        public override void Load()
        {
            Bind<DAL.Interfaces.IRepositoryDB>().To<DAL.Repository.SQLRepositoryDB>().InSingletonScope().WithConstructorArgument(connection);
            Bind<BLL.Model.ModelBasket>().ToSelf();
            //Bind<BLL.Service.ServiceCart>().To<BLL.Model.ModelBasket>();
        }
    }
}
