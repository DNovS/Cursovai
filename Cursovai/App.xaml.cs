using BLL.Util;
using Cursovai.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL.Interfaces;

namespace Cursovai
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModul("ModelContext"));

            IDBCrud crud = kernel.Get<BLL.Interfaces.IDBCrud>();
            IServiceReport report = kernel.Get<BLL.Interfaces.IServiceReport>();
            IServiceOrder order = kernel.Get<BLL.Interfaces.IServiceOrder>();
            IServiceHistory history = kernel.Get<BLL.Interfaces.IServiceHistory>();
            IServiceCart cart = kernel.Get<IServiceCart>();

            MainWindow mainWindow = new MainWindow(crud,
                                                   order,
                                                   report,
                                                   history,
                                                   cart);

            mainWindow.Show();
        }
    }
}
