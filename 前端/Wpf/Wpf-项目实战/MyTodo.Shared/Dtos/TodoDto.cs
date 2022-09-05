using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyTodo.Shared.Dtos
{
    public class TodoDto:BaseDto
    {
    
        private string title;
        private int status;
        private string content;

        public string Content
        {
            get { return content; }
            set { 
                content = value;
                OnPropertyChanged();
            }
        }

        public int Status
        {
            get { return status; }
            set { 
                status = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged();
            }
        }

    }
}
