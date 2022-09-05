using MyTodoApp.Extensions;
using MyTodoApp.Models;
using Prism.Commands;
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
    public class SettingsViewModel:BindableBase
    {
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
 
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public SettingsViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<MenuBar>(Navgate);
            CreateMenuBar();
        }

        private void Navgate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace)) 
                return;

            regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);
        }

        public ObservableCollection<MenuBar> MenuBars
        {  
            get { return menuBars; }
            set { menuBars = value; }
        }
        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar { Icon = "", Title = "个性化", NameSpace = "SkinView" });
            MenuBars.Add(new MenuBar { Icon = "", Title = "系统设置", NameSpace = "" });
            MenuBars.Add(new MenuBar { Icon = "", Title = "关于更多", NameSpace = "AboutView" });
        }

    }
}
