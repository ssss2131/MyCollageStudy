using MyTodoApp.Common;
using MyTodoApp.Extensions;
using MyTodoApp.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.ViewModels
{
    public class MainViewModel:BindableBase,IConfigureService 
    {
        public MainViewModel(IRegionManager regionManager,IContainerProvider containerProvider)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            LogingOutCommand = new DelegateCommand(logingOut);
            AppCenterCommand = new DelegateCommand(appCenter);
            this.regionManager = regionManager;
            this.containerProvider = containerProvider;
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null&& journal.CanGoForward)
                    journal.GoForward();
            });
        }

        private void appCenter()
        {
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("AppCenterView");
        }

        private void logingOut()
        {
            App.logingOut(containerProvider);
        }

        private void Navigate(MenuBar obj)
        {
            if (obj==null||string.IsNullOrWhiteSpace(obj.NameSpace))
                return;
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back => {
                journal = back.Context.NavigationService.Journal;//获取导航日志
            });//获取到前台注册的Region区域 并做请求导航到标题

            
        }
        #region 一）、驱动整个导航的命令
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand AppCenterCommand { get; set; }
        private readonly IRegionManager regionManager;
        private readonly IContainerProvider containerProvider;
        private IRegionNavigationJournal journal;
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand LogingOutCommand { get; private set; }

        #endregion

        #region 数据双向绑定

        private ObservableCollection<MenuBar> menuBars;
    
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; 
                RaisePropertyChanged(); }
        }
  

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar { Icon="Home",NameSpace="IndexView",Title="首页"});
            MenuBars.Add(new MenuBar { Icon = "NotebookOutline", NameSpace = "TodoView", Title = "待办事项" });
            MenuBars.Add(new MenuBar { Icon = "NotebookPlus", NameSpace = "MemoView", Title = "备忘录" });
            MenuBars.Add(new MenuBar { Icon = "Cog", NameSpace = "SettingsView", Title = "设置" });
        }

        public void Configure()
        {
            CreateMenuBar();
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }

        #endregion

    }
}
