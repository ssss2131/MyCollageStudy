using DryIoc;
using MyTodoApp.Common;
using MyTodoApp.Service;
using MyTodoApp.ViewModels;
using MyTodoApp.ViewModels.Dialog;
using MyTodoApp.Views;
using MyTodoApp.Views.Dialog;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyTodoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
   

        public static void logingOut(IContainerProvider containerProvider)
        {
            Current.MainWindow.Hide();
            var dialog = containerProvider.Resolve<IDialogHostService>();
            dialog.ShowDialog("LoginView", callback: callBack =>
            {
                if (callBack.Result != ButtonResult.OK)
                {
                    Application.Current.Shutdown();
                    return;
                }

            });
            Current.MainWindow.Show();
        }

        public DelegateCommand AppCenterCommand { get; set; }
 
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();//返回应用程序的主窗口 MainView
        }
        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogHostService>();
            dialog.ShowDialog("LoginView", callback: callBack =>
            {
                if (callBack.Result != ButtonResult.OK)
                {
                    Application.Current.Shutdown();
                    return;
                }

            });
            var service = App.Current.MainWindow.DataContext as IConfigureService;
            if (service != null)
            {
                service.Configure();
            }
            base.OnInitialized();

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)//自定义注册一些服务
        {
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            containerRegistry.GetContainer().RegisterInstance(@"http://101.42.173.26/", serviceKey: "webUrl");
            containerRegistry.Register<ITodoService, TodoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            containerRegistry.Register<IDialogHostService,DialogHostService>();
            containerRegistry.Register<ILoginService, LoginService>();

            //一）、实现导航
            //注册导航服务 模型,视图 弹窗

            containerRegistry.RegisterForNavigation<AppCenterView>();//---待开发


            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();          
            containerRegistry.RegisterForNavigation<AddToDoDialogView, AddToDoViewModel>();
            containerRegistry.RegisterForNavigation<AddMemoDialogView, AddMemoViewModel>();
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<TodoView, TodoViewModel>() ;
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
        }
    }
}
