using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Cursovai.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<BLL.Interfaces.IDBCrud>().To<BLL.DBDO>();
            Bind<BLL.Interfaces.IServiceHistory>().To<BLL.Service.ServiceHistory>();
            Bind<BLL.Interfaces.IServiceOrder>().To<BLL.Service.ServiceOrder>();
            Bind<BLL.Interfaces.IServiceReport>().To<BLL.Service.ServiceReport>();
            Bind<BLL.Interfaces.IServiceCart>().To<BLL.Service.ServiceCart>();
        }
    }
}
