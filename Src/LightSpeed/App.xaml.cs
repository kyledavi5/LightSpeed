using Prism.Ioc;
using LightSpeed.Views;
using System.Windows;
using Prism.Modularity;
using LightSpeed.Core;
using LightSpeed.Data;
using LightSpeed.Projects;

namespace LightSpeed
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        { 
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CoreModule>();
            moduleCatalog.AddModule<DataModule>();
            moduleCatalog.AddModule<ProjectModule>();
        }
    }
}
