using BLL.Interfaces;
using BLL.Model;
using System.Collections.ObjectModel;
using Cursovai.Classes;
using System.Windows.Input;

namespace Cursovai.ViewModel
{
    class BasketViewModel : BaseViewModel
    {
        private readonly IDBCrud _DB;
        private readonly IServiceCart cart;
        private readonly IServiceOrder order;

        public BasketViewModel(IDBCrud dB, IServiceCart cart, IServiceOrder order)
        {
            _DB = dB;
            this.cart = cart;
            this.order = order;
            var items = cart.line();
            _technics = new ObservableCollection<ModelTechnic>();
            foreach (var i in items)
            {
                _technics.Add(dB.ModelTechnics.Find(t => t.id_technic == i.id_technic));
            }
        }
        #region Удалить из корзины
        //private ICommand _DeleteTechnic;
        public ICommand DeleteTechnic
        {
            get
            {
                return new RelayCommand(args => _DeleteTechnictoCart(args));
            }
        }
        private void _DeleteTechnictoCart(object args)
        {
            if (cart.line().Find(i => i.id_technic == technic.id_technic) != null)
            {
                cart.DeleteTechnic(technic);
                _technics.Remove(technic);
            }
        }
        #endregion


        #region Оформить заказ
        //private ICommand _MakeOrder;
        public ICommand MakeOrder
        {
            get
            {
                return new RelayCommand(args => BuyToTehnic(args));
            }
        }
        private void BuyToTehnic(object args)
        {
            ModelOrder modelOrder = new ModelOrder()
            {
                lineOrders = cart.line()
            };
            Window_Order _Order = new Window_Order(modelOrder, order);
            _Order.ShowDialog();
        }

        public Window_OrderViewModel window { get; set; }
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
        public string visible
        {
            get
            {
                if (_technic != null)
                    return "Visible";
                else return "Hidden";
            }
        }
        public string visible_order
        {
            get
            {
                if (_technics.Count > 0) 
                    return "Visible";
                else return "Hidden";
            }
        }
        private int _count;
        public int count
        {
            get
            {
                if (_technic != null)
                    _count = cart.line().Find(i => i.id_technic == _technic.id_technic).quantity;
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged("");
            }
        }

    }
}
