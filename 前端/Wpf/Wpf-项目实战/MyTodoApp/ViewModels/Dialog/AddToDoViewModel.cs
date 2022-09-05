using MaterialDesignThemes.Wpf;
using MyTodo.Shared.Dtos;
using MyTodoApp.Common;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.ViewModels.Dialog
{
    public class AddToDoViewModel :BindableBase, IDialogHostAware
    {
        public AddToDoViewModel()
        {
            SaveCommand = new DelegateCommand(save);
            CancelCommand = new DelegateCommand(cancel);
        }
        private TodoDto model;
        public string DialogHostName {get; set;}
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
     

        public TodoDto Model
        {
            get { return model; }
            set { model = value;
                RaisePropertyChanged();
            }
        }

        private void cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
                DialogHost.Close(DialogHostName,new DialogResult(ButtonResult.Cancel));
        }
        private void save()
        {
          
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters param = new DialogParameters();
         
                param.Add("Value", Model);
                DialogHost.Close(DialogHostName,new DialogResult(ButtonResult.OK, param));
            }
        }
        public void OnDialogOpend(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Value"))
            {
                Model = parameters.GetValue<TodoDto>("Value");
            }
            else
                Model = new TodoDto();
        }
    }
}
