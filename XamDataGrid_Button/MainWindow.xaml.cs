using Infragistics.Windows;
using Infragistics.Windows.DataPresenter;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace XamDataGrid_Button
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainModel();
        }
    }

    public class MainModel : INotifyPropertyChanged
    {
        public DelegateCommand MyCommand { get; set; }
        public MainModel()
        {
            m_gridData = new ObservableCollection<TestData>();

            for (int i = 0; i < 10; i++)
            {
                m_gridData.Add(new TestData { Id = i, Test1 = "button " + i, Test2 = "Test" + i });
            }

            MyCommand = new DelegateCommand(MyCommand_Execute);
        }

        private ObservableCollection<TestData> m_gridData;
        public ObservableCollection<TestData> GridData
        {
            get { return m_gridData; }
            set
            {
                m_gridData = value;
                NotifyPropertyChanged("GridData");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public void MyCommand_Execute()
        {
            DataRecordPresenter drp = Utilities.GetAncestorFromType(Mouse.DirectlyOver as DependencyObject, typeof(DataRecordPresenter), false) as DataRecordPresenter;

            if (drp != null)
            {
                DataRecord record = drp.Record as DataRecord;
                MessageBox.Show((record.DataItem as TestData).Id + " is clicked.");
            }
        }
    }

    public class TestData : INotifyPropertyChanged
    {
        private int m_id;
        public int Id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private String m_test1;
        public String Test1
        {
            get { return m_test1; }
            set
            {
                m_test1 = value;
                NotifyPropertyChanged("Test1");
            }
        }

        private String m_test2;
        public String Test2
        {
            get { return m_test2; }
            set
            {
                m_test2 = value;
                NotifyPropertyChanged("Test2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
