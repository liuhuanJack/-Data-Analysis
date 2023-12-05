using SciChart.Charting.Visuals;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Caliburn.Micro.Tutorial.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Set this code once in App.xaml.cs or application startup before any SciChartSurface is shown 
            SciChartSurface.SetRuntimeLicenseKey("IVFRayQ0KRYeV72R6V5Nr2+Egz62LJrYjoK+32fSiZwV7CoBKiU69MyjSz0Tfbgdo11TUxkfK/I38VhOcIRuYOf5xD//bNssB+owdXlz5vfg2nxk9X6gi9raZNXqwjPb0YqkfbALis5l5hleWEOLJLEbP/hbboTtiqkV90XV7k/pF0j+Y7LssVVFVM9zC6/5MWx5smOUyIzNBis0zyac8nHhxPzIFt48z/zrsJYkMvK6SoVSjyQp6gyqPUz5CEdVWkBcIl5pjoMv79GuSnIjRNEoX+76VMxq+wUALWQDuFpAcXacrgNUBVtOB/tuwXiQtnEqWUwhcfJK5XiA45/+cYWV1J3L8G/wAPJctb29nPzwoDdt5dkNUBWMXJ1fAJUbXANE0xQ9+6Z/OYUBeYF3DOqpmRsUpr3plgU/raRgfbq+/G2n/XU/ezX3TdIjQmg5va08FYNKcd/jT3pTa4F0gh9fxVgT5gvGIRrvrGfrJC1/cwolCEupvkWAOcyIoHdiUp2ESQLoUBKTf5b8/aHvnlUDj4XHvODuxH1pDMMQahZxqRfhjPXuWGK/kqAD38I8XalU0oLmqXLPtumkLLbQCrWJq9Y4aH3mYLk2IVabRg==");
        }
    }
}
