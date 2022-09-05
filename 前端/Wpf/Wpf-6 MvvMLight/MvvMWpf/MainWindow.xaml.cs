using MvvMWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
 
 
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvMWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //分别为ComboBox ListBox提供数据
            List<Color> ColorList = new List<Color>();
            ColorList.Add(new Color() { Code = "#FF8C00" });
            ColorList.Add(new Color() { Code = "#FF7F50" });
            ColorList.Add(new Color() { Code = "#FF6EB4" });
            ColorList.Add(new Color() { Code = "#FF4500" });
            ColorList.Add(new Color() { Code = "#FF3030" });
            ColorList.Add(new Color() { Code = "#CD5B45" });
            //为itemControl绑定数据
            List<Test> tests = new List<Test>();
            tests.Add(new Test() { Code = "1" });
            tests.Add(new Test() { Code = "2" });
            tests.Add(new Test() { Code = "3" });
            tests.Add(new Test() { Code = "4" });
            tests.Add(new Test() { Code = "6" });
            ic.ItemsSource = tests;
            cob.ItemsSource = ColorList;
            lib.ItemsSource = ColorList;
            this.DataContext = new MainViewModel();
        }
    }
    public class Color
    {
        public string? Code { get; set; }
    }
    public class Test
    {
        public string? Code { get; set; }
    }
}

