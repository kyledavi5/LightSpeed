using Prism.Ioc;
using LightSpeed.Views;
using System.Windows;
using Prism.Modularity;


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
            moduleCatalog.AddModule<Core.CoreModule>();
            moduleCatalog.AddModule<Common.CommonModule>();
            moduleCatalog.AddModule<Data.DataModule>();
            moduleCatalog.AddModule<Customers.CustomersModule>();
        }
    }
}
