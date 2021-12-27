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
using BLL.Interfaces;
using BLL.Model;
using Cursovai.ViewModel;

namespace Cursovai.View
{
    /// <summary>
    /// Логика взаимодействия для Window_OrderHistory.xaml
    /// </summary>
    public partial class Window_OrderHistory : Window
    {
        public Window_OrderHistory(IServiceHistory history, ModelOrder order)
        {
            DataContext = new OrderHistoryViewModel(order, history);
            InitializeComponent();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
