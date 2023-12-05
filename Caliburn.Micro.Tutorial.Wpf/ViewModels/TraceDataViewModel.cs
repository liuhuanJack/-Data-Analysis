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
    public class TraceDataViewModel : Conductor<object>, IHandle<List<string[]>>, IHandle<SelectedDataListItems>, IHandle<ObservableCollection<RecipeDataList>>
    {
        public ObservableCollection<RecipeDataList> _recipeData;
        /// <summary>
        /// 所跑Recipe的数据列表
        /// </summary>
        public ObservableCollection<RecipeDataList> RecipeData
        {
            get { return _recipeData; }
            set
            {
                _recipeData = value;
                NotifyOfPropertyChange(() => RecipeData);
            }
        }
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
        private List<string> _selectedDatas;
        public List<string> SelectedDatas
        {
            get { return _selectedDatas; }
            set
            {
                _selectedDatas = value;
                NotifyOfPropertyChange(() => SelectedDatas);
            }
        }
        private string _chartTitle = "Hello SciChart World!";
        private string _xAxisTitle = "XAxis";
        private string _yAxisTitle = "YAxis";

        private ObservableCollection<IRenderableSeriesViewModel> _renderableSeries;

        List<XyDataSeries<DateTime, double>> dataSeriesList = new List<XyDataSeries<DateTime, double>>();

        [Obsolete]
        public TraceDataViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            
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
        public Task HandleAsync(ObservableCollection<RecipeDataList> message, CancellationToken cancellationToken)
        {
            RecipeData = message;
            return Task.CompletedTask;
        }

        public Task HandleAsync(SelectedDataListItems message, CancellationToken cancellationToken)
        {
            SelectedData = message;
            SelectedDatas = SelectedData.Data;
            List<DateTime> datetime = new List<DateTime>();
            List<string> strings = new List<string>();
            RenderableSeries = new ObservableCollection<IRenderableSeriesViewModel>();
            strings = ReceiveData.Skip(3).Select(row => row[0]).ToList();
            datetime = strings.Select(s => DateTime.ParseExact(s, "'T'yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)).ToList();
            List<int> ints = new List<int>();
            int j = 0;
            for (int i = 0; i < ReceiveData[3].Length; i++)
            {
                if (j < SelectedDatas.Count)
                {
                    if (ReceiveData[2][i] == SelectedDatas[j])
                    {
                        ints.Add(i);
                        j++;
                    }
                }
                else
                    break;
            }
            j = 0;
            for (int i = 0; i < SelectedDatas.Count; i++)
            {
                var lineData = new XyDataSeries<DateTime, double>() { SeriesName = SelectedDatas[i] };
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
                if (hasValidData)
                {
                    dataSeriesList.Add(lineData);
                    RenderableSeries.Add(new LineRenderableSeriesViewModel()
                    {
                        StrokeThickness = 2,
                        Stroke = RecipeData[0].Color.Color,
                        DataSeries = lineData,
                        StyleKey = "LineSeriesStyle"
                    });
                }
            }
            return Task.CompletedTask;
        }
    }
}
