using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Model;
using System.Collections.ObjectModel;
using Cursovai.View;

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
        private ModelOrder _order;
        public ModelOrder order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                if (_order != null)
                {
                    Window_OrderHistory window = new Window_OrderHistory(history, _order);
                    window.ShowDialog();
                    _orders = new ObservableCollection<ModelOrder>(history.orders());
                }
                OnPropertyChanged("");
        } }
    }
}
