using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;

namespace Caliburn.Micro.Tutorial.Wpf.ViewModels
{
    public class AddFileViewModel : Screen
    {
        private string _fileContent;
        public string FileContent
        {
            get { return _fileContent; }
            set
            {
                _fileContent = value;
                NotifyOfPropertyChange(() => FileContent);
            }
        }

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                NotifyOfPropertyChange(() => FileName);
            }
        }
        private readonly IEventAggregator _eventAggregator;
        public List<string[]> CsvData { get; set; }

        public string[] newData { get; set; }
        public AddFileViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            //_eventAggregator.PublishOnUIThreadAsync(new List<string[]>(csvData));
            //_eventAggregator.PublishOnUIThreadAsync("Hello World");
            //_eventAggregator.PublishOnUIThreadAsync(22);
        }

        public void SelectFilesCommand()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                CsvData = ReadCSV(filePath);

                if (CsvData.Count > 2) // 确保第三行存在
                {
                    string[] row = CsvData[2];
                    if (row.Length > 3) // 确保至少有四个数据
                    {
                        newData = new string[row.Length - 3];
                        Array.Copy(row, 3, newData, 0, row.Length - 3);
                        // 现在newData数组中包含了第四个及以后的数据
                    }
                }
                //FileContent = File.ReadAllText(filePath);
                FileName = Path.GetFileName(openFileDialog.FileName);
            }
        }

        private List<string[]> ReadCSV(string filePath)
        {
            List<string[]> data = new List<string[]>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    data.Add(fields);
                }
            }

            return data;
        }

        public void AddFilesCommand()
        {
            _eventAggregator.PublishOnUIThreadAsync(CsvData);
            _eventAggregator.PublishOnUIThreadAsync(FileName);
            //_eventAggregator.PublishOnUIThread(new DataArrayMessage(newData));
            //Messenger.Default.Send<String>(FileContent, "Message");
            MessageBox.Show("已添加文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //public Task HandleAsync(DataArrayMessage message, CancellationToken cancellationToken)
        //{
        //    string[] receivedData = message.NewData;
        //    // 在这里处理接收到的数据
        //    return Task.CompletedTask;
        //}

    }
}
