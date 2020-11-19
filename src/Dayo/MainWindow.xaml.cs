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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dayo
{

 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;

        private const string StorageName = "DayoStore.txt";


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            StoreMemoryList();
        }

        private void StoreMemoryList()
        {
            System.IO.File.WriteAllText(StorageName, viewModel.Content);
        }

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
            ReadMemoryList();

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Start();
        }

        private void ReadMemoryList()
        {
            if (System.IO.File.Exists(StorageName))
            {
                viewModel.Content = System.IO.File.ReadAllText(StorageName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StoreMemoryList();

            this.Close();
        }

        private void AddCheckbox_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Content = viewModel.Content.Insert(MemoryList.CaretIndex, "\u2610");
            MemoryList.Focus();
        }

        //private void MemoryList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (viewModel.Content == "")
        //    {
        //        return;
        //    }
        //    char curentChar = viewModel.Content[MemoryList.CaretIndex];
        //    if (curentChar == '\u2610')
        //    {
        //        viewModel.Content = viewModel.Content.Substring(0, MemoryList.CaretIndex) +  "\u2611" + viewModel.Content.Substring(MemoryList.CaretIndex+1);
        //    } 
        //    else if (curentChar == '\u2611')
        //    {
        //        viewModel.Content = viewModel.Content.Substring(0, MemoryList.CaretIndex) + "\u2610" + viewModel.Content.Substring(MemoryList.CaretIndex + 1);
        //    }
        //}

        private void MemoryList_MouseDown(object sender, MouseButtonEventArgs e)
        {  
            if (viewModel.Content == "")
            {
                return;
            }
            char curentChar = MemoryList.CaretIndex == viewModel.Content.Length ? (char)0 : viewModel.Content[MemoryList.CaretIndex];
            if (curentChar == '\u2610')
            {
                viewModel.Content = viewModel.Content.Substring(0, MemoryList.CaretIndex) + "\u2611" + viewModel.Content.Substring(MemoryList.CaretIndex + 1);
            }
            else if (curentChar == '\u2611')
            {
                viewModel.Content = viewModel.Content.Substring(0, MemoryList.CaretIndex) + "\u2610" + viewModel.Content.Substring(MemoryList.CaretIndex + 1);
            }
        }

        private void DraggableRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
