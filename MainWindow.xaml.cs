using BLL.Util;
using Cursovai.Util;
using Ninject;
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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BLL.Interfaces.IDBCrud crud;
        BLL.Interfaces.IServiceOrder order;
        BLL.Interfaces.IServiceReport report;
        BLL.Interfaces.IServiceHistory history;
        UserControl_Main _Main;
        public MainWindow()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModul("ModelContext"));

            crud = kernel.Get<BLL.Interfaces.IDBCrud>();
            report = kernel.Get<BLL.Interfaces.IServiceReport>();
            order = kernel.Get<BLL.Interfaces.IServiceOrder>();
            history = kernel.Get<BLL.Interfaces.IServiceHistory>();

            _Main = new UserControl_Main(crud.ModelTechnics);

            Load();
        }
        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Load()
        {
            GridPrincipal.Children.Add(_Main);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(_Main);
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_Report(report));
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_Basket(crud.ModelTechnics, _Main.id));
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_History(crud.ModelOrders));
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
    }
}

