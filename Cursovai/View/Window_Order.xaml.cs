using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cursovai.ViewModel;

namespace Cursovai
{
    /// <summary>
    /// Логика взаимодействия для Window_Order.xaml
    /// </summary>
    public partial class Window_Order : Window
    {
        //BLL.Model.ModelOrder modelOrder;
        //BLL.Interfaces.IServiceOrder service;
        public Window_Order(BLL.Model.ModelOrder model, BLL.Interfaces.IServiceOrder order)
        {
            InitializeComponent();
            DataContext = new Window_OrderViewModel(order, model);
            //this.modelOrder = model;
            //this.service = order;
            //LoadContent();
        }

        //public void LoadContent()
        //{
        //    modelOrder = service.MakeOrder(modelOrder);
        //    date.Text = modelOrder.registration_date.ToString();
        //    cost.Text = modelOrder.cost.ToString();
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (fcs.Text == "")
        //    {
        //        MessageBox.Show("Введите ФИО");
        //    }
        //    modelOrder.id_client = 1; //лень считать
        //    if (code.Text != "") modelOrder = service.Use_Code(modelOrder, code.Text.ToString());
        //    service.CreateOrder(modelOrder);
        //    this.Close();
        //}

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
