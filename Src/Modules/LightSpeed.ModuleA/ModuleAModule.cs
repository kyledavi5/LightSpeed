using LightSpeed.Common.Dialogs;
using LightSpeed.ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LightSpeed.ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("RightRegion", typeof(MasterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasterView>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }
    }
}