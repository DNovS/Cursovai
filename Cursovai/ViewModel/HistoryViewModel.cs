using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Model;
using System.Collections.ObjectModel;

namespace Cursovai.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        private readonly IServiceHistory history;

        public HistoryViewModel(IServiceHistory history)
        {
            this.history = history;
            _orders = new ObservableCollection<ModelOrder>(history.orders());
            
        }

        private ObservableCollection<ModelOrder> _orders;
        public ObservableCollection<ModelOrder> orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged("");
            }
        }
    }
}
