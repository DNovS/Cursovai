using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using System.Collections.ObjectModel;
using BLL.Model;

namespace Cursovai.ViewModel
{
    class StocksViewModel : BaseViewModel
    {
        private readonly IDBCrud dB;

        public StocksViewModel(IDBCrud dB)
        {
            this.dB = dB;
            _promoCodes = new ObservableCollection<ModelPromoCode>(dB.ModelPromoCodes.Where(i => i.number_use > 0)) ;
        }
        private ObservableCollection<ModelPromoCode> _promoCodes { get; set; }
        public ObservableCollection<ModelPromoCode> promoCodes
        {
            get
            {
                return _promoCodes;
            }
            set
            {
                _promoCodes = value;
                OnPropertyChanged("");
            }
        }
    }
}
