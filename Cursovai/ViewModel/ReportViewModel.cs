using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Cursovai.Classes;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows;

namespace Cursovai.ViewModel
{
    class ReportViewModel : BaseViewModel
    {
        private readonly IServiceReport report;
        private readonly IDBCrud dB;

        public ReportViewModel(IServiceReport report, IDBCrud dB, CartesianChart chart)
        {
            this.report = report;
            this.dB = dB;
            this._chart = chart;
            var value = dB.ModelOrders.Where(o => o.registration_date != null).GroupBy(o => new DateTime
            (
                o.registration_date.Year,
                o.registration_date.Month,
                o.registration_date.Day)
            ).OrderBy(o => o.Key).Select(o=> o.Key).ToList();
            _start_times = new ObservableCollection<DateTime>(value);
            _end_times = new ObservableCollection<DateTime>(value);
        }

        #region Поиск
        //private ICommand _search { get; set; }
        public ICommand search {
            get
            {
                return new RelayCommand(args => _Search(args));
            }
        }

        private void _Search(object args)
        {
            if (_start_time != null && _end_time != null)
            {
                foreach (var series in _chart.Series)
                {
                    series.Values.Clear();
                }
                _chart.AxisX.Clear();
                _chart.AxisY.Clear();
                ColumnSeries column_expectation = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    Title = "Ожидают",
                    LabelPoint = p => p.Y.ToString(),
                };
                ColumnSeries column_completion = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    Title = "Выполнены",
                    LabelPoint = p => p.Y.ToString(),
                };
                ColumnSeries column_cancelletion = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<int>(),
                    Title = "Отменены",
                    LabelPoint = p => p.Y.ToString(),
                };
                Axis axis = new Axis() { Separator = new LiveCharts.Wpf.Separator() { Step = 1, IsEnabled = false } };
                axis.Labels = new List<string>();
                var foriach = report.Graphics(_start_time, _end_time);
                foreach (var x in foriach)
                {
                    column_expectation.Values.Add(x.Total_expectation);
                    column_completion.Values.Add(x.Total_completion);
                    column_cancelletion.Values.Add(x.Total_cancellation);
                    axis.Labels.Add(x.date.ToString());
                }
                if (column_expectation != null)
                    _chart.Series.Add(column_expectation);
                if (column_completion != null)
                    _chart.Series.Add(column_completion);
                if (column_cancelletion != null)
                    _chart.Series.Add(column_cancelletion);
                _chart.AxisX.Add(axis);
                _chart.AxisY.Add(new Axis
                {
                    LabelFormatter = v => v.ToString(),
                    Separator = new LiveCharts.Wpf.Separator(),
                });
            }
            else MessageBox.Show("Выбирите временной промежуток");
        }
        #endregion

        private ObservableCollection<DateTime> _start_times { get; set; }
        public ObservableCollection<DateTime> start_times
        {
            get
            {
                return _start_times;
            }
            set
            {
                _start_times = value;
                OnPropertyChanged("");
            }
        }
        private ObservableCollection<DateTime> _end_times { get; set; }
        public ObservableCollection<DateTime> end_times
        {
            get
            {
                return _end_times;
            }
            set
            {
                _end_times = value;
                OnPropertyChanged("");
            }
        }
        private CartesianChart _chart { get; set; }
        public CartesianChart chart
        {
            get
            {
                return _chart;
            }
            set
            {
                _chart = value;
                OnPropertyChanged("");
            }
        }
        private DateTime _start_time { get; set; }
        public DateTime start_time
        {
            get
            {
                return _start_time;
            }
            set
            {
                _start_time = value;
                OnPropertyChanged("");
            }
        }
        private DateTime _end_time { get; set; }
        public DateTime end_time
        {
            get
            {
                return _end_time;
            }
            set
            {
                _end_time = value;
                OnPropertyChanged("");
            }
        }
    }
}
