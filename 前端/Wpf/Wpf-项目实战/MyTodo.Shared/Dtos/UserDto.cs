using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Shared.Dtos
{
    public class UserDto:BaseDto
    {
        private string userName;
        private string account;
        private string passWord;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }
        public string Account
        {
            get { return account; }
            set { account = value;
                OnPropertyChanged();
            }
        }     
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value;
                OnPropertyChanged();
            }
        }



    }
}
