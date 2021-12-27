using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovai.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private readonly IDBCrud _DB;
        private readonly IServiceOrder _order;
        private readonly IServiceReport _report;
        private readonly IServiceHistory _history;

        public MainWindowViewModel(IDBCrud dB, IServiceOrder order, IServiceReport report, IServiceHistory history)
        {
            _DB = dB;
            _order = order;
            _report = report;
            _history = history;
        }
    }
}
