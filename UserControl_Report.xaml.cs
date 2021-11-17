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
using LiveCharts.Wpf;
using LiveCharts;

namespace Cursovai
{
    /// <summary>
    /// Логика взаимодействия для UserControl_Report.xaml
    /// </summary>
    public partial class UserControl_Report : UserControl
    {
        public UserControl_Report(BLL.Interfaces.IServiceReport report)
        {
            InitializeComponent();
            LoadElemet(report);
        }

        public void LoadElemet(BLL.Interfaces.IServiceReport report)
        {
            ColumnSeries column = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<int>(),
                LabelPoint = p => p.Y.ToString(),
            };
            Axis axis = new Axis() {Separator = new LiveCharts.Wpf.Separator() { Step = 1, IsEnabled = false }};
            axis.Labels = new List<string>();
            foreach (var x in report.Graphics)
            {
                column.Values.Add(x.Total);
                axis.Labels.Add(x.date.ToString());
            }
            chart.Series.Add(column);
            chart.AxisX.Add(axis);
            chart.AxisY.Add(new Axis
            {
                LabelFormatter = v => v.ToString(),
                Separator = new LiveCharts.Wpf.Separator(),
            });
        }
    }
}
