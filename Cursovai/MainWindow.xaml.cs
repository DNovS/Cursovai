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
using Cursovai.View;

namespace Cursovai
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IDBCrud crud;
        IServiceOrder order;
        IServiceReport report;
        IServiceHistory history;
        IServiceCart cart;

        //UserControl_Main _Main;
        public MainWindow(IDBCrud crud,
                          IServiceOrder order,
                          IServiceReport report,
                          IServiceHistory history,
                          IServiceCart cart)
        {
            InitializeComponent();
            this.history = history;
            this.crud = crud;
            this.order = order;
            this.report = report;
            this.cart = cart;

            Load();
        }
        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Load()
        {
            GridPrincipal.Children.Add(new UserControl_Main(crud,cart));
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
                    GridPrincipal.Children.Add(new UserControl_Main(crud, cart));
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_Stocks(crud));
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_Report(report, crud));
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_Basket(crud, order, cart));
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControl_History(history));
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
