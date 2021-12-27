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
using Cursovai.ViewModel;
using BLL.Interfaces;

namespace Cursovai.View
{
    /// <summary>
    /// Логика взаимодействия для UserControl_Main.xaml
    /// </summary>
    public partial class UserControl_Main : UserControl
    {
        public UserControl_Main(IDBCrud db, IServiceCart cart)
        {
            DataContext = new MainViewModel(db, cart);
            InitializeComponent();
        }

        //private void LoadControll()
        //{
        //    for (int i = 0; i < modelTechnics.Count; i++)
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
        //    if (Technic.SelectedIndex >= 0) id.Add(modelTechnics[Technic.SelectedIndex].id_technic);
        //}
    }
}
