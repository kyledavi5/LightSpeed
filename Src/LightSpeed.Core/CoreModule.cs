using LightSpeed.Core.Dialogs;
using LightSpeed.Core.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LightSpeed.Core
{
    public class CoreModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("HeaderRegion", typeof(MenuView));
            regionManager.RegisterViewWithRegion("NavigationRegion", typeof(NavigationView));
            regionManager.RegisterViewWithRegion("ApplicationOptionsContentRegion", typeof(ApplicationOptionViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ApplicationOptionsDialog, ApplicationOptionsDialogViewModel>();
        }

    }
}