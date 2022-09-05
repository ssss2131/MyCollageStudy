using MyTodo.Shared.Dtos;
using MyTodoApp.Common;
using MyTodoApp.Extensions;
using MyTodoApp.Service;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel(ILoginService service,IEventAggregator eventAggregator)
        {
            ExecuteCommand = new DelegateCommand<string>(execute);
            this.service = service;
            this.eventAggregator = eventAggregator;
            RegistDto = new RegisterUserDto();
        }

    

        private string userName;
        private string account;
        private string passWord;
        private int selectedIndex;

   


        public event Action<IDialogResult> RequestClose;
        public string Title { get; set; } = "ToDo";

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private readonly ILoginService service;
        private readonly IEventAggregator eventAggregator;
        private RegisterUserDto registDto;

   

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged();
            }
        }
        public string Account
        {
            get { return account; }
            set
            {
                account = value;
                RaisePropertyChanged();
            }
        }
        public string PassWord
        {
            get { return passWord; }
            set
            {
                passWord = value;
                RaisePropertyChanged();
            }
        }
        public RegisterUserDto RegistDto
        {
            get { return registDto; }
            set
            {
                registDto = value;
                RaisePropertyChanged();
            }
        }

        private void execute(string obj)
        {
            switch (obj)
            {
                case "Login":
                    Login();
                    break;
                case "LoginOut":
                    LoginOut();
                    break;
                case "Resgiter":
                    Registe();
                    break;
                case "Go":
                    SelectedIndex = 1;
                    break;
                case "Return":
                    SelectedIndex = 0;
                    break;
            }
        }

        private void Back()
        {
         
        }

        private void Go()
        {
            
        }

        private async void Registe()
        {
            if (string.IsNullOrWhiteSpace(registDto.PassWord) ||
                    string.IsNullOrWhiteSpace(registDto.Account) || string.IsNullOrWhiteSpace(registDto.NewPassWord) || string.IsNullOrWhiteSpace(registDto.UserName)
                    || !registDto.PassWord.Equals(registDto.NewPassWord))
                return;

            var registerRes = await service.RegisterAsync(new UserDto()
            {
                Account = RegistDto.Account,
                PassWord = RegistDto.PassWord,
                UserName = RegistDto.UserName
            });
            if (registerRes.Status)
            {
                execute("Return");
            }
            return;

        }

        private void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));

        }

        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(Account) || string.IsNullOrWhiteSpace(PassWord))
            {
                eventAggregator.SendMessage(new Common.Event.MessageModel { Message = "登录失败！账号或密码不能为空" },"Login");
                return;
            }

            var loginResult = await service.LoginAsync(new UserDto()
            {
                Account = Account,
                PassWord = PassWord,
            });
            if (loginResult.Status)
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                eventAggregator.SendMessage(new Common.Event.MessageModel { Message = $"登陆成功！欢迎用户{loginResult.Result.UserName} 今天是{DateTime.Now}" } );
                AppSession.UserName = loginResult.Result.UserName;
                return;
            }
            eventAggregator.SendMessage(new Common.Event.MessageModel { Message = "登陆失败！账号或者密码不正确" }, "Login");
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
