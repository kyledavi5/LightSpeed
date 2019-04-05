using LightSpeed.ModuleA.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSpeed.ModuleA.ViewModels
{
    public class MasterViewViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<Gizmo> _moduleAItems;
        public ObservableCollection<Gizmo> ModuleAItems
        {
            get { return _moduleAItems; }
            set { SetProperty(ref _moduleAItems, value); }
        }

        public MasterViewViewModel()
        {
            ModuleAItems = new ObservableCollection<Gizmo>();
            ModuleAItems.Add(new Gizmo() { Name = "test" });
            ModuleAItems.Add(new Gizmo() { Name = "test" });
            ModuleAItems.Add(new Gizmo() { Name = "test" });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
