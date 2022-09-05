using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace RegionModulNav.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> OpenDialogCommand { get; private set; }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager,IDialogService  dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            OpenDialogCommand = new DelegateCommand<string>(Open);
        }

        private void Open(string obj)
        {
            _dialogService.ShowDialog(obj);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath, NavigationComplete);
        }
        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }
    }
}
