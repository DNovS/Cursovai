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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Interfaces;
using Cursovai.ViewModel;

namespace Cursovai.View
{
    /// <summary>
    /// Логика взаимодействия для UserControl_Stocks.xaml
    /// </summary>
    public partial class UserControl_Stocks : UserControl
    {
        public UserControl_Stocks(IDBCrud dB)
        {
            DataContext = new StocksViewModel(dB);
            InitializeComponent();
        }
    }
}
