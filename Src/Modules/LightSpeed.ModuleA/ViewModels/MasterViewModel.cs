using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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

        private IDialogService _dialogService;

        private ObservableCollection<object> _moduleAItems;
        public ObservableCollection<object> ModuleAItems
        {
            get { return _moduleAItems; }
            set { SetProperty(ref _moduleAItems, value); }
        }

        public DelegateCommand ShowDialogCommand { get; private set; }

        public MasterViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            ModuleAItems = new ObservableCollection<object>();
            ShowDialogCommand = new DelegateCommand(ShowNotificationDialog);
            
        }

        private void ShowNotificationDialog()
        {

            var message = "Not Implemented Yet";

            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>

            {
                if (r.Result.HasValue)
                {
                    if (r.Result == true)
                    {

                    }
                    else if (r.Result == false)
                    {

                    }
                    else
                    {

                    }
                }
            });
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
