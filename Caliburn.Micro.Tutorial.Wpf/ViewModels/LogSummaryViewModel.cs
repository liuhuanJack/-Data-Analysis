using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Caliburn.Micro.Tutorial.Wpf.ViewModels
{
    class LogSummaryViewModel : Screen
    {
        //public static class ListBoxHelper
        //{
        //    public static readonly DependencyProperty SelectedItemsProperty =
        //        DependencyProperty.RegisterAttached("SelectedItems", typeof(IList), typeof(ListBoxHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //    public static void SetSelectedItems(DependencyObject element, IList value)
        //    {
        //        element.SetValue(SelectedItemsProperty, value);
        //    }

        //    public static IList GetSelectedItems(DependencyObject element)
        //    {
        //        return (IList)element.GetValue(SelectedItemsProperty);
        //    }
        //}
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }
    }
}
