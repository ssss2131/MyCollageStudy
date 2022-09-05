using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel: BindableBase,INavigationAware
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private int _pageViews;
        private IRegionNavigationJournal _journal;

        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }
        public DelegateCommand GoBackCommand { get; set; }
        public ViewBViewModel()
        {
            GoBackCommand = new DelegateCommand(goBack);
            Message = "View B from your Prism Module";
        }

      

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
             
        } 
        private void goBack()
        {
            if(!_journal.CanGoBack)
            {
                return;
            }
            _journal.GoBack();          
        }
    }
}
