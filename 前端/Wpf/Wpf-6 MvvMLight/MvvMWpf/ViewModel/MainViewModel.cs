using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel; 
using System.Windows;

namespace MvvMWpf.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()　
        {
            MyCompanyName = "xxx公司";
            Workers = new ObservableCollection<Worker>();
            Workers.Add(new Worker(id: 1, name: "张三", role: "普通员工"));
            Workers.Add(new Worker(id: 2, name: "李四", role: "普通员工"));
            Workers.Add(new Worker(id: 3, name: "王五", role: "项目经理"));
            Workers.Add(new Worker(id: 4, name: "刘六", role: "普通员工"));
            Workers.Add(new Worker(id: 5, name: "赵七", role: "普通员工"));    
        }
        private string? myCompanyName;

        public string? MyCompanyName
        {
            get { return myCompanyName; }
            set { myCompanyName = value; RaisePropertyChanged(); }
        }

       

        private ObservableCollection<Worker>? workers;
        public ObservableCollection<Worker>? Workers
        {
            get { return workers; }
            set { workers = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand<Worker>? command;

        public RelayCommand<Worker>? Command
        {
            get {
                if (command == null)
                {
                    command = new RelayCommand<Worker>((t) => Recommand(t));
                }
                return command; 
            }       
        }
        private void Recommand(Worker worker)
        {
            if (worker is null)
            {
                MessageBox.Show("请选中员工");
                return;
            }
            MessageBox.Show($"员工编号{worker.id}\t员工名称{worker.name}\t员工角色{worker.role}");
        }
        private RelayCommand? updateCommand;

        public RelayCommand? UpdateCommand
        {
            get {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(() => updateText());
                }
                return updateCommand; 
            }
             
        }
        private void updateText()
        {
            MyCompanyName = "未知名称公司";
        }

    }
}
