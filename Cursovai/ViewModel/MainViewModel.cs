using BLL.Interfaces;
using BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cursovai.Classes;

namespace Cursovai.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDBCrud _DB;
        private readonly IServiceCart cart;

        public MainViewModel(IDBCrud dB, IServiceCart cart)
        {
            _DB = dB;
            this.cart = cart;
            var items = dB.ModelTechnics;
            _technics = new ObservableCollection<ModelTechnic>();
            foreach(var i in items)
            {
                _technics.Add(i);
            }

        }
        #region Добавление в корзину
        //private ICommand _AddTechnic;
        public ICommand AddTechnic
        {
            get
            {
                return new RelayCommand(args => _AddTechnictoCart(args));
            }
        }
        private void _AddTechnictoCart (object args)
        {
            if (cart.line().Find(i => i.id_technic == technic.id_technic) == null) cart.AddTechnic(technic, 1);
        }
        #endregion

        private ObservableCollection<ModelTechnic> _technics;
        public ObservableCollection<ModelTechnic> technics
        {
            get
            {
                return _technics;
            }
            set
            {
                technics = value;
                OnPropertyChanged("");   
            }
        }
        private ModelTechnic _technic;
        public ModelTechnic technic
        {
            get
            {
                return _technic;
            }
            set
            {
                _technic = value;
                OnPropertyChanged("");
            }
        }
    }
}
