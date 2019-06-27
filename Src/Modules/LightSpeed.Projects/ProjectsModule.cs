
using LightSpeed.Projects.ViewModels;
using LightSpeed.Projects.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LightSpeed.Projects
{
    public class ProjectModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ProjectsMasterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ProjectsMasterView>();
            containerRegistry.RegisterDialog<CreateProjectDialog, CreateProjectDialogViewModel>();
            containerRegistry.RegisterDialog<ProjectDetailsDialog, ProjectDetailsDialogViewModel>();
            containerRegistry.RegisterSingleton<IProjectRepository, ProjectRepository>();
        }
    }
}