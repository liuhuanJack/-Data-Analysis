using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using System.Windows.Media;
using SciChart.Data.Model;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections;
using System.Windows.Controls;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Threading;
using SciChart.Charting.Visuals.RenderableSeries;
using static Caliburn.Micro.Tutorial.Wpf.ViewModels.ELAViewModel;
using System.Windows.Markup;
using System.Globalization;
using SciChart.Charting.Visuals;

namespace Caliburn.Micro.Tutorial.Wpf.ViewModels
{
    public class TraceDataViewModel : Conductor<object>, IHandle<List<string[]>>, IHandle<SelectedDataListItems>
    {
        private readonly IEventAggregator _eventAggregator;

        private List<string[]> _receiveData;
        public List<string[]> ReceiveData
        {
            get { return _receiveData; }
            set
            {
                _receiveData = value;
                NotifyOfPropertyChange(() => ReceiveData);
            }
        }
        private SelectedDataListItems _selectedData;
        public SelectedDataListItems SelectedData
        {
            get { return _selectedData; }
            set
            {
                _selectedData = value;
                NotifyOfPropertyChange(() => SelectedData);
            }
        }
        private List<string> _text;
        public List<string> Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyOfPropertyChange(() => Text);
            }
        }
        private string _chartTitle = "Hello SciChart World!";
        private string _xAxisTitle = "XAxis";
        private string _yAxisTitle = "YAxis";

        private ObservableCollection<IRenderableSeriesViewModel> _renderableSeries;

        [Obsolete]
        public TraceDataViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _renderableSeries = new ObservableCollection<IRenderableSeriesViewModel>();
            SelectedData = new SelectedDataListItems();
        }
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries
        {
            get { return _renderableSeries; }
            set
            {
                _renderableSeries = value;
                NotifyOfPropertyChange(nameof(RenderableSeries));
            }
        }
        public string ChartTitle
        {
            get { return _chartTitle; }
            set
            {
                _chartTitle = value;
                NotifyOfPropertyChange("ChartTitle");
            }
        }
        public string XAxisTitle
        {
            get { return _xAxisTitle; }
            set
            {
                _xAxisTitle = value;
                NotifyOfPropertyChange("XAxisTitle");
            }
        }
        public string YAxisTitle
        {
            get { return _yAxisTitle; }
            set
            {
                _yAxisTitle = value;
                NotifyOfPropertyChange("YAxisTitle");
            }
        }
        private bool _enableZoom = true;
        public bool EnableZoom
        {
            get { return _enableZoom; }
            set
            {
                if (_enableZoom != value)
                {
                    _enableZoom = value;
                    NotifyOfPropertyChange("EnableZoom");
                    if (_enableZoom) EnablePan = false;
                }
            }
        }
        private bool _enablePan;
        public bool EnablePan
        {
            get { return _enablePan; }
            set
            {
                if (_enablePan != value)
                {
                    _enablePan = value;
                    NotifyOfPropertyChange("EnablePan");
                    if (_enablePan) EnableZoom = false;
                }
            }
        }
        public Task HandleAsync(List<string[]> message, CancellationToken cancellationToken)
        {
            ReceiveData = message;
            return Task.CompletedTask;
        }

        public Task HandleAsync(SelectedDataListItems message, CancellationToken cancellationToken)
        {
            SelectedData = message;
            Text = SelectedData.Data;
            List<DateTime> datetime = new List<DateTime>();
            List<string> strings = new List<string>();
            strings = ReceiveData.Skip(3).Select(row => row[0]).ToList();
            datetime = strings.Select(s => DateTime.ParseExact(s, "'T'yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)).ToList();
            List<int> ints = new List<int>();
            int j = 0;
            for (int i = 0; i < ReceiveData[3].Length; i++)
            {
                if (j < Text.Count)
                {
                    if (ReceiveData[2][i] == Text[j])
                    {
                        ints.Add(i);
                        j++;
                    }
                }
                else
                    break;

            }
            List<XyDataSeries<DateTime, double>> dataSeriesList = new List<XyDataSeries<DateTime, double>>();
            j = 0;
            for (int i = 0; i < Text.Count; i++)
            {
                var lineData = new XyDataSeries<DateTime, double>() { SeriesName = Text[i] };
                bool hasValidData = false;
                for (int k = 0; k < datetime.Count; k++)
                {
                    if (double.TryParse(ReceiveData[k + 3][ints[j]], out double dataValue))
                    {
                        lineData.Append(datetime[k], dataValue);
                        hasValidData = true;
                    }
                }
                j++;
                if (hasValidData && !dataSeriesList.Contains(lineData))
                {
                    dataSeriesList.Add(lineData);
                    RenderableSeries.Add(new LineRenderableSeriesViewModel()
                    {
                        StrokeThickness = 2,
                        Stroke = Colors.SteelBlue,
                        DataSeries = lineData,
                        StyleKey = "LineSeriesStyle"
                    });
                }
            }
            return Task.CompletedTask;
        }
    }
}
