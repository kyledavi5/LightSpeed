using LightSpeed.Common.Dialogs;
using LightSpeed.Common.Services;
using LightSpeed.Something.Dialogs;
using LightSpeed.Something.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LightSpeed.Something
{
    public class SomethingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(SomethingMasterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SomethingMasterView>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.RegisterDialog<SomethingDetailsDialog, SomethingDetailsDialogViewModel>();
            containerRegistry.RegisterSingleton<ISomethingRepository, SomethingRepository>();
        }
    }
}