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
    public class MasterViewModel : BindableBase, INavigationAware
    {

        private ObservableCollection<object> _moduleAItems;
        public ObservableCollection<object> ModuleAItems
        {
            get { return _moduleAItems; }
            set { SetProperty(ref _moduleAItems, value); }
        }

        public MasterViewModel()
        {
            ModuleAItems = new ObservableCollection<object>();
            
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
