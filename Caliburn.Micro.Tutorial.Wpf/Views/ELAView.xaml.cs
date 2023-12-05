using Caliburn.Micro.Tutorial.Wpf.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Window = System.Windows.Window;

namespace Caliburn.Micro.Tutorial.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ELAView.xaml
    /// </summary>
    public partial class ELAView : Window
    {
        public ELAView()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            //mModel = new ELAViewModel();
            //this.DataContext = mModel;
        }
    }
}
