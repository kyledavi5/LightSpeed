using LightSpeed.Common.Dialogs;
using LightSpeed.Common.Services;
using LightSpeed.Somethings.Dialogs;
using LightSpeed.Somethings.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LightSpeed.Somethings
{
    public class SomethingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(SomethingsMasterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SomethingsMasterView>();
            containerRegistry.RegisterDialog<CreateSomethingDialog, CreateSomethingDialogViewModel>();
            containerRegistry.RegisterDialog<SomethingDetailsDialog, SomethingDetailsDialogViewModel>();
            containerRegistry.RegisterSingleton<ISomethingRepository, SomethingRepository>();
        }
    }
}