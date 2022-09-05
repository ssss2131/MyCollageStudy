﻿using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA.ViewModels
{
    public class ViewCViewModel : IDialogAware
    {
        public string Title => "弹窗标题";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
             
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
