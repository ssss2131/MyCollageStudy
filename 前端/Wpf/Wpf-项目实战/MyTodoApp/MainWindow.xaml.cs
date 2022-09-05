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

namespace MyTodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            this.btnMax.Click +=(s,e) => {
                switch (this.WindowState)
                {
                    case WindowState.Normal:
                        this.WindowState = WindowState.Maximized;
                        this.btnMax.Content = "❏";
                        break;
                    case WindowState.Maximized:
                        this.WindowState = WindowState.Normal;
                        this.btnMax.Content = "❐";
                        break;
                }              
            };
            this.btnClose.Click+=(s,e)=> {
                this.Close();               
            };
            this.ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
            this.ColorZone.MouseDoubleClick += (s, e) =>
            {
                switch (this.WindowState)
                {
                    case WindowState.Maximized:
                            this.WindowState = WindowState.Normal;
                            this.btnMax.Content = "❐";
                        break;
                    case WindowState.Normal:
                            this.WindowState = WindowState.Maximized;
                            this.btnMax.Content = "❏";
                        break;

                }
               
            };
        }
    }
}
