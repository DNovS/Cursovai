using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cursovai.Classes;

namespace Cursovai.ViewModel
{
    public class OrderHistoryViewModel : BaseViewModel
    {
        private readonly ModelOrder _order;
        private readonly IServiceHistory history;
        
        public OrderHistoryViewModel(ModelOrder order, IServiceHistory history)
        {
            this.history = history;
            this._order = order;
            _technics = new ObservableCollection<ModelTechnic>(history.technics(order));
        }
        private ObservableCollection<ModelTechnic> _technics;
        public ObservableCollection<ModelTechnic> technics
        { 
            get
            {
                return _technics;
            }
            set
            {
                _technics = value;
                OnPropertyChanged("");
            }
        }
        public ModelOrder order
        {
            get
            {
                return _order;
            }
        }

        //private ICommand _cancel;
        public ICommand cancel
        {
            get
            {
                return new RelayCommand(args => Cancelled(args));
            }
        }
        
        private void Cancelled (object args)
        {
            history.cancel(_order);
        }
    }
}
