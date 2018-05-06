using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Wpf.Controls;

namespace ImageTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel();
        }

        public class ViewModel : INotifyPropertyChanged
        {
            public ICollectionView Images { get; private set; }
            public ViewModel()
            {
                //var folder = @"C:\images";
                var folder = @"C:\Users\ower\Pictures";
                var photos = System.IO.Directory.EnumerateFiles(folder, "*.jpg", SearchOption.AllDirectories);

                Images = CollectionViewSource.GetDefaultView(photos);
                RaisePropertyChanged("Images");
            }

            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged(string propName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
    }
}
