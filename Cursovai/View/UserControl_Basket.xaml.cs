using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class UserControl_Basket : UserControl
    {
        //IDBCrud dB;
        //IServiceOrder order;
        //IServiceCart cart;
        public UserControl_Basket(IDBCrud dB, IServiceOrder order, IServiceCart cart)
        {
            InitializeComponent();
            DataContext = new BasketViewModel(dB, cart, order);
        }

        //private void LoadControll()
        //{
        //    for (int i = 0; i < modelTechnics.Count && 0 != id.Find(o => o == modelTechnics[i].id_technic); i++)
        //    {
        //        Technic.Items.Add(modelTechnics[i].name);
        //    }
        //}
        //private void ChangedControll(object sender, SelectionChangedEventArgs e)
        //{
        //    if (modelTechnics[Technic.SelectedIndex].name != null) name.Text = modelTechnics[Technic.SelectedIndex].name;
        //    if (modelTechnics[Technic.SelectedIndex].cost.ToString() != null) cost.Text = modelTechnics[Technic.SelectedIndex].cost.ToString();
        //    if (modelTechnics[Technic.SelectedIndex].specifications != null) specification.Text = modelTechnics[Technic.SelectedIndex].specifications;

        //    if (modelTechnics[Technic.SelectedIndex].image != null)
        //    {
        //        Stream stream = new MemoryStream(modelTechnics[Technic.SelectedIndex].image);
        //        BitmapImage bitmap = new BitmapImage();
        //        bitmap.BeginInit();
        //        bitmap.StreamSource = stream;
        //        bitmap.EndInit();
        //        image.Source = bitmap;
        //    }
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Technic.SelectedIndex >= 0) id.Remove(modelTechnics[Technic.SelectedIndex].id_technic);
        //}

        //private void Button_Buy(object sender, RoutedEventArgs e)
        //{
        //    List<int> q = new List<int>();
        //    for (int i = 0; i < id.Count; i++) q.Add(1);
        //    BLL.Model.ModelOrder modelOrder = new BLL.Model.ModelOrder()
        //    {
        //        line = id,
        //        quant = q,
        //    };
        //    Window_Order _Order = new Window_Order(modelOrder, serviceOrder);
        //    _Order.ShowDialog();
        //}
    }
}
