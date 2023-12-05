using Caliburn.Micro.Tutorial.Wpf.ViewModels;
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
using System.Windows.Shapes;

namespace Caliburn.Micro.Tutorial.Wpf.Views
{
    /// <summary>
    /// TraceDataView.xaml 的交互逻辑
    /// </summary>
    public partial class TraceDataView
    {
        public TraceDataView()
        {
            InitializeComponent();
            //DataContext = new TraceDataViewModel();
        }
    }
}
