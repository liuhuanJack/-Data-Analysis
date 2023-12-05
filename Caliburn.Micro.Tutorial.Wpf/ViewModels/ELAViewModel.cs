using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic.Logging;
using Prism.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using static Caliburn.Micro.Tutorial.Wpf.ViewModels.ELAViewModel;



namespace Caliburn.Micro.Tutorial.Wpf.ViewModels
{
    public class ELAViewModel : Conductor<object>, IHandle<string>, IHandle<List<string[]>>
    {
        public ObservableCollection<RecipeDataList> _recipeData;

        public ObservableCollection<RecipeDataList> RecipeData
        {
            get { return _recipeData; }
            set
            {
                _recipeData = value;
                NotifyOfPropertyChange(() => RecipeData);
            }
        }

        public ObservableCollection<Node> Nodes { get; set; }

        private ObservableCollection<ToolItems> _toolitems;
        /// <summary>
        /// 机台列表
        /// </summary>
        public ObservableCollection<ToolItems> ToolItems
        {
            get { return _toolitems; }
            set
            {
                _toolitems = value;
                NotifyOfPropertyChange(() => ToolItems);
            }
        }

        public ObservableCollection<ChamberItems> _chamberitems;
        /// <summary>
        /// 腔室列表
        /// </summary>
        public ObservableCollection<ChamberItems> ChamberItems
        {
            get { return _chamberitems; }
            set
            {
                _chamberitems = value;
                NotifyOfPropertyChange(() => ChamberItems);
            }
        }

        public List<string> _selectedToolItems;
        /// <summary>
        /// 已选机台列表
        /// </summary>
        public List<string> SelectedToolItems
        {
            get { return _selectedToolItems; }
            set
            {
                _selectedToolItems = value;
                NotifyOfPropertyChange(() => SelectedToolItems);
            }
        }

        public List<string> _selectedChambers;
        /// <summary>
        /// 已选腔室列表
        /// </summary>
        public List<string> SelectedChambers
        {
            get { return _selectedChambers; }
            set
            {
                _selectedChambers = value;
                NotifyOfPropertyChange(() => SelectedChambers);
            }
        }
        private string _searchText;
        /// <summary>
        /// 参数搜索框
        /// </summary>
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    NotifyOfPropertyChange(() => SearchText);
                }
            }
        }

        private string _receiveInfo;
        /// <summary>
        /// 添加的文件传递过来的数据
        /// </summary>
        public string ReceiveInfo
        {
            get { return _receiveInfo; }
            set
            {
                if (_receiveInfo != value)
                {
                    _receiveInfo = value;
                    NotifyOfPropertyChange(() => ReceiveInfo);
                }
            }
        }

        private RecipeDataList _selectedRecipe;

        public RecipeDataList SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                NotifyOfPropertyChange(() => SelectedRecipe);
            }
        }

        private readonly IWindowManager _windowManager;

        private readonly IEventAggregator _eventAggregator;
        //public string ReceiveData { get; set; }

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
        private string[] _dataList;

        public string[] DataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
                NotifyOfPropertyChange(() => DataList);
            }
        }
        public ObservableCollection<DataListItems> _datalistitems;
        /// <summary>
        /// 参数列表
        /// </summary>
        public ObservableCollection<DataListItems> DataListItems
        {
            get { return _datalistitems; }
            set
            {
                _datalistitems = value;
                NotifyOfPropertyChange(() => DataListItems);
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
        private string _filename;

        public string FileName
        {
            get { return _filename; }
            set
            {
                _filename = value;
                NotifyOfPropertyChange(() => FileName);
            }
        }

        [Obsolete]
        public ELAViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            // 初始化数据源
            RecipeData = new ObservableCollection<RecipeDataList>();

            Nodes = new ObservableCollection<Node>();

            ToolItems = new ObservableCollection<ToolItems>
            {
                new ToolItems { Tool = "1001", IsSelected = false },
                new ToolItems { Tool = "1002", IsSelected = false },
                new ToolItems { Tool = "1003", IsSelected = false },
                new ToolItems { Tool = "1004", IsSelected = false },
                new ToolItems { Tool = "1005", IsSelected = false },
                new ToolItems { Tool = "1006", IsSelected = false },
                new ToolItems { Tool = "1007", IsSelected = false },
                new ToolItems { Tool = "1008", IsSelected = false },
                new ToolItems { Tool = "1009", IsSelected = false },
                new ToolItems { Tool = "1010", IsSelected = false },
            };

            ChamberItems = new ObservableCollection<ChamberItems>
            {
                new ChamberItems { Chamber = "PM1", IsSelected = false },
                new ChamberItems { Chamber = "PM2", IsSelected = false },
                new ChamberItems { Chamber = "PM3", IsSelected = false },
                new ChamberItems { Chamber = "PM4", IsSelected = false },
            };
            SelectedData = new SelectedDataListItems();
            _windowManager = windowManager;

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        protected async override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await EditCategories();
        }
        public Task EditCategories()
        {
            var viewmodel = IoC.Get<TraceDataViewModel>();
            return ActivateItemAsync(viewmodel, new CancellationToken());
        }
        public void DataCommand()
        {
            SelectedData.Data = new List<string>();
            for (int i = 0; i < DataListItems.Count; i++)
            {
                if (DataListItems[i].IsSelected == true)
                {

                    //SelectedData.Add(new SelectedDataListItems { Data = DataListItems[i] });
                    //SelectedData.Add(new SelectedDataListItems { Data});
                    SelectedData.Data.Add(DataListItems[i].Data);
                }
            }
            _eventAggregator.PublishOnUIThreadAsync(SelectedData);
        }
        public void ProcessData()
        {
            if (ReceiveData.Count > 2) // 确保第三行存在
            {
                string[] row = ReceiveData[2];
                if (row.Length > 3) // 确保至少有四个数据
                {
                    DataList = new string[row.Length - 3];
                    Array.Copy(row, 3, DataList, 0, row.Length - 3);
                    // 现在DataList数组中包含了第四个及以后的数据
                }
                DataListItems = new ObservableCollection<DataListItems> { };
                for(int i = 0; i < DataList.Length; i++)
                {
                    DataListItems.Add(new DataListItems { Data = DataList[i], IsSelected = false });
                }
                string searchData = "Chamber.LeakCheckRate";
                int index = DataListItems.ToList().FindIndex(item => item.Data == searchData);

                

                string start = ReceiveData[1][0];
                string end = ReceiveData[ReceiveData.Count - 1][0];
                string? chamber = null;
                string? tool = null;
                if(SelectedChambers != null)
                    chamber = String.Join(", ", SelectedChambers);
                if(SelectedToolItems != null)
                    tool = String.Join(", ", SelectedToolItems);
                DateTime start_time = DateTime.ParseExact(start, "'#Create Date: 'yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime end_time = DateTime.ParseExact(end, "'T'yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
                RecipeData = new ObservableCollection<RecipeDataList> { };
                RecipeData.Add(new RecipeDataList { Index = 1, Visible = false, StartTime = start_time,
                                                    EndTime = end_time, FileName = FileName, Tool = tool, Chamber = chamber, 
                                                    Recipe = "", LotID = "", Slot = 1, Color = new SolidColorBrush(Colors.Red) });
                RecipeData[0].Color = new SolidColorBrush(Colors.SteelBlue);
            }
        }
        public Task HandleAsync(string message, CancellationToken cancellationToken)
        {
            FileName = message;
            ProcessData();
            return Task.CompletedTask;
        }
        public Task HandleAsync(List<string[]> message, CancellationToken cancellationToken)
        {
            ReceiveData = message;
            return Task.CompletedTask;
        }
        public Task AddFile()
        {
            return _windowManager.ShowDialogAsync(IoC.Get<AddFileViewModel>());
        }
        public Task LogSummary()
        {
            return _windowManager.ShowDialogAsync(IoC.Get<LogSummaryViewModel>());
        }
        public void ShowSelectedItems()
        {
            StringBuilder selectedItems = new();
            foreach (var item in ToolItems)
            {
                if (item.IsSelected)
                {
                    selectedItems.Append(item.Tool);
                    selectedItems.Append(", ");
                }
            }
            if (selectedItems.Length > 0)
            {
                selectedItems.Length -= 2; // 移除最后的逗号和空格
                //System.Windows.Forms.MessageBox.Show("Selected Tools: " + selectedItems.ToString());
                string[] words = selectedItems.ToString().Split(", ");
                SelectedToolItems = new List<string>(words);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Tools selected");
            }
            selectedItems = new();
            foreach (var item in ChamberItems)
            {
                if (item.IsSelected)
                {
                    selectedItems.Append(item.Chamber);
                    selectedItems.Append(", ");
                }
            }
            if (selectedItems.Length > 0)
            {
                selectedItems.Length -= 2; // 移除最后的逗号和空格
                //System.Windows.Forms.MessageBox.Show("Selected Chambers: " + selectedItems.ToString());
                string[] words = selectedItems.ToString().Split(", ");
                SelectedChambers = new List<string>(words);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Chambers selected");
            }
        }
        //Recipe数据的列表类定义
        public class RecipeDataList : Screen
        {
            public int Index { get; set; }
            public bool Visible { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string FileName { get; set; }
            public string? Tool { get; set; }
            public string? Chamber { get; set; }
            public string Recipe { get; set; }
            public string LotID { get; set; }
            public int Slot { get; set; }

            private SolidColorBrush _color;
            public SolidColorBrush Color
            {
                get { return _color; }
                set
                {
                    _color = value;
                    NotifyOfPropertyChange(() => Color);
                }
            }

        }
        public class SelectedDataListItems
        {
            public List<string> Data { get; set; }
        }

        //参数节点的定义
        public class Node : Screen
        {
            private string name;
            /// <summary>
            /// 该节点的名称
            /// </summary>
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
            private bool isSelected;
            /// <summary>
            /// 该节点是否被选中
            /// </summary>
            public bool IsSelected
            {
                get { return isSelected; }
                set
                {
                    isSelected = value;
                    NotifyOfPropertyChange(() => IsSelected);
                }
            }
            private ObservableCollection<Node> children;
            /// <summary>
            /// 该节点的子节点
            /// </summary>
            public ObservableCollection<Node> Children
            {
                get { return children; }
                set
                {
                    children = value;
                    NotifyOfPropertyChange(() => Children);
                }
            }

            private bool _isSearchResult;
            /// <summary>
            /// 节点是否在搜索范围
            /// </summary>
            public bool IsSearchResult
            {
                get { return _isSearchResult; }
                set
                {
                    if (_isSearchResult != value)
                    {
                        _isSearchResult = value;
                        NotifyOfPropertyChange(() => IsSearchResult);
                    }
                }
            }
        }

        private RecipeDataList _recipe;
        //实现Query功能，目前主要实现添加数据的功能，未实现根据Chamber和Tool进行Query
        public void QueryDatasCommand()
        {
            Random ran = new();

            for (int j = 0; j < 25; j++)
            {
                _recipe = new RecipeDataList
                {
                    Index = j,
                    Visible = (j % 2 == 1),
                    StartTime = new DateTime(2023, 10, 25, 9, 0, 0),
                    EndTime = new DateTime(2023, 10, 25, 11, 0, 0),
                    FileName = $"File {j + 1}",
                    Tool = "1001",
                    Chamber = "PM1",
                    Recipe = "",
                    LotID = $"Lot {j + 1}",
                    Slot = ran.Next(1, 30),
                    //Color = System.Drawing.Color.Blue
                    Color = new SolidColorBrush(Colors.Red)
                };

                if (!RecipeData.Any(n => n.FileName == _recipe.FileName))
                {
                    RecipeData.Add(_recipe);
                }
            }

            //添加根节点
            Node rootNode = new() { Name = "Chuck" };

            //添加子节点
            Node childNode1 = new() { Name = "Chuck.Chiller" };
            Node childNode2 = new() { Name = "Chuck.ChuckDC" };
            rootNode.Children = new ObservableCollection<Node> { childNode1, childNode2 };

            //添加孙子节点
            Node grandchildNode1 = new() { Name = "Chuck.Chiller.FeedBack" };
            Node grandchildNode2 = new() { Name = "Chuck.Chiller.IsOn" };
            Node grandchildNode3 = new() { Name = "Chuck.Chiller.Online" };
            childNode1.Children = new ObservableCollection<Node> { grandchildNode1, grandchildNode2, grandchildNode3 };

            //如果节点已存在，就不添加该节点
            if (!Nodes.Any(n => n.Name == rootNode.Name))
            {
                Nodes.Add(rootNode);
            }
        }

        public void QueryFilesCommand()
        {
            string[]? dataParts = null;
            /// <summary>
            /// 判定文件是否为空或是否添加文件；如果没有，就抛出异常，如果有，就将文件数据添加到列表里
            /// </summary>
            if (ReceiveInfo != null && ReceiveInfo != "")
            {
                dataParts = ReceiveInfo.Split(';');
                _recipe = new RecipeDataList
                {
                    Visible = bool.Parse(dataParts[0]),
                    StartTime = DateTime.Parse(dataParts[1]),
                    EndTime = DateTime.Parse(dataParts[2]),
                    FileName = dataParts[3],
                    Tool = dataParts[4],
                    Chamber = dataParts[5],
                    Recipe = dataParts[6],
                    LotID = dataParts[7],
                    Slot = int.Parse(dataParts[8]),
                    //Color = dataParts[9]
                };
                //如果数据重复，就不添加该数据
                if (!RecipeData.Any(n => n.FileName == _recipe.FileName))
                {
                    RecipeData.Add(_recipe);
                }
            }
            else
            {
                //处理ReceiveInfo为null的情况
                System.Windows.Forms.MessageBox.Show("未添加文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchCommand()
        {
            if(SearchText != null)
            {
                for (int i = 0; i < DataListItems.Count; i++)
                {
                    if (DataListItems[i].Data.Contains(SearchText))
                    {
                        DataListItems[i].IsSearchResult = true;
                    }
                    else
                    {
                        DataListItems[i].IsSearchResult = false;
                    }
                }
            }
            else
                System.Windows.Forms.MessageBox.Show("搜索参数不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #region 树结构时实现参数搜索功能
        //遍历节点修改IsSearchResult，新建复制节点，将原节点赋给复制节点，clear掉原节点，添加新节点
        public void ExecuteEnterCommand()
        {
            Traversal(Nodes[0]);

            Node rootNodeCopy = CreateCopyOfNode(Nodes[0]);

            Nodes.Clear();

            if (!Nodes.Any(n => n.Name == rootNodeCopy.Name))
            {
                Nodes.Add(rootNodeCopy);
            }
        }

        //复制节点
        public Node CreateCopyOfNode(Node node)
        {
            Node newNode = new()
            {
                Name = node.Name,
                IsSelected = node.IsSelected,
                IsSearchResult = node.IsSearchResult
            };

            //遍历子节点
            if (node.Children != null)
            {
                newNode.Children = new ObservableCollection<Node>();
                foreach (var childNode in node.Children)
                {
                    Node newChildNode = CreateCopyOfNode(childNode);
                    newNode.Children.Add(newChildNode);
                }
            }

            return newNode;
        }

        //遍历节点，修改节点的IsSearchResult
        public void Traversal(Node node)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                System.Windows.Forms.MessageBox.Show("搜索内容不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (/*string.IsNullOrEmpty(SearchText) || */node.Name.Contains(SearchText))
            {
                node.IsSearchResult = true;
            }
            else
            {
                node.IsSearchResult = false;
            }

            // 遍历子节点
            if (node.Children != null)
            {
                foreach (var childNode in node.Children)
                {
                    Traversal(childNode);
                }
            }
        }
        #endregion

        //通过此方法，将传递的参数设为string
        private void ShowReceiveInfo(String msg)
        {
            ReceiveInfo += msg;
        }

        public void ChangeColorsCommand(RecipeDataList parameter)
        {
            ColorDialog colorDialog = new();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color selectedColor = colorDialog.Color;
                if (parameter != null)
                {
                    RecipeDataList recipe = parameter as RecipeDataList;
                    if (recipe != null)
                    {
                        // 修改颜色
                        recipe.Color = new SolidColorBrush(Color.FromArgb(selectedColor.A, selectedColor.R, selectedColor.G, selectedColor.B));// 新的颜色值

                        // 通知界面更新
                        //recipe.OnPropertyChanged("Color");
                        //NotifyOfPropertyChange(() => Color);

                    }
                }
            }
        }
    }

    public class ToolItems : Screen
    {
        private string _tool;
        private bool _isSelected;

        public string Tool
        {
            get { return _tool; }
            set
            {
                _tool = value;
                NotifyOfPropertyChange(() => Tool);
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }
    }

    public class ChamberItems : Screen
    {
        private string _chamber;
        private bool _isSelected;

        public string Chamber
        {
            get { return _chamber; }
            set
            {
                _chamber = value;
                NotifyOfPropertyChange(() => Chamber);
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }
    }

    public class DataListItems : Screen
    {
        private string _data;
        private bool _isSelected;
        private bool _isSearchResult;

        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        public bool IsSearchResult
        {
            get { return _isSearchResult; }
            set
            {
                if (_isSearchResult != value)
                {
                    _isSearchResult = value;
                    NotifyOfPropertyChange(() => IsSearchResult);
                }
            }
        }
    }

}