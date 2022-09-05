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

namespace Binding;
 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //this.DataContext = new Test("来自该页面DataContext的Name"); 
        //一个页面的DataContext会被后面重复出现的DataContext覆盖
        PageModel page = new PageModel();
        page.ClassName = "三年二班";
        page.Students = new List<Student>();
        page.Students?.Add(new Student("张三", 18, "男"));
        page.Students?.Add(new Student("李四", 19, "男"));
        page.Students?.Add(new Student("王五", 20, "男"));
        this.DataContext = page;
    }
}

public class PageModel
{
    public string? ClassName { get; set; }
    public List<Student>? Students { get; set; }
}

public record Student(string Name, int Age, string Sex)
{

}