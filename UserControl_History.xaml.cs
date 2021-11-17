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

namespace Cursovai
{
    public partial class UserControl_History : UserControl
    {
        private List <BLL.Model.ModelOrder> orders;
        public UserControl_History(List <BLL.Model.ModelOrder> model)
        {
            InitializeComponent();
            this.orders = model;
            Load();
        }
        private void Load()
        {
            order.Content = orders;
        }
    }
}
