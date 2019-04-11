using LightSpeed.Common.Dialogs;
using LightSpeed.Customers.Dialogs;
using LightSpeed.Customers.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LightSpeed.Customers
{
    public class CustomersModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("RightRegion", typeof(CustomersMasterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomersMasterView>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.RegisterDialog<CustomerDetailsDialog, CustomerDetailsDialogViewModel>();
        }
    }
}