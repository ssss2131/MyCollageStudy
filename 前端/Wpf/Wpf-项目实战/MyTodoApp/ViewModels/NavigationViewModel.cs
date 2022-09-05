using MyTodoApp.Extensions;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
 
namespace MyTodoApp.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IContainerProvider containerProvider;
        public readonly IEventAggregator eventAggregator;
        public NavigationViewModel(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
            eventAggregator = containerProvider.Resolve<IEventAggregator>();
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)　
        {
            
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
             
        }
        public void UpdateLoading(bool isOpen)
        {
            this.eventAggregator.UpdateLoading(new Common.Event.UpdateModel()
            {
                IsOpen = isOpen
            }); 
        }
    }
}
