using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cursovai.Classes;
using System.Windows.Input;
using BLL.Model;
using BLL.Interfaces;
using System.Windows;

namespace Cursovai.ViewModel
{
    public class Window_OrderViewModel : BaseViewModel
    {
        private readonly IServiceOrder order;

        public Window_OrderViewModel(IServiceOrder order, ModelOrder modelOrder)
        {
            this.order = order;
            _model = order.MakeOrder(modelOrder);
        }

        #region Заказать
        //private ICommand _Ordered;
        public ICommand Ordered
        {
            get
            {
                return new RelayCommand(args => CreateOrder(args));
            }
        }
        private void CreateOrder(object args)
        {
            if (_model.fcs == null)
            {
                MessageBox.Show("Введите ФИО");
            }
            _model.id_client = 1; //лень считать
            if (_model.code != null) _model = order.Use_Code(_model,  model.code);
            order.CreateOrder(_model);
        }

        #endregion

        private ModelOrder _model { get; set; }
        public ModelOrder model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged("");
            }
        }
    }
}
