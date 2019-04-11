using LightSpeed.Data.Models;
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
using LightSpeed.Data;
using System.ComponentModel;
using System.Windows.Data;
using LightSpeed.Common.Dialogs;

namespace LightSpeed.Customers.ViewModels
{
    public class CustomersMasterViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private Customer _selectedItem;
        public Customer SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        private ObservableCollection<Customer> _customerCollection;
        public ObservableCollection<Customer> CustomerCollection
        {
            get { return _customerCollection; }
            set { SetProperty(ref _customerCollection, value); }
        }

        private DelegateCommand<string> _openCustomerDetailsDialogCommand;
        public DelegateCommand<string> OpenNewCustomerDialogCommand =>
            _openCustomerDetailsDialogCommand ?? (_openCustomerDetailsDialogCommand = new DelegateCommand<string>(OpenCustomerDetailsDialog));

        void OpenCustomerDetailsDialog(string dataMode)
        {
            if (dataMode == "Edit")
            {
                var customerId = SelectedItem.Id;
                
            _dialogService.ShowDialog("CustomerDetailsDialog", new DialogParameters($"IdentifierID={customerId},DataDialogMode={dataMode}"), r => 
            {
                LoadTableData();
            });
            }
            
        }

        public CustomersMasterViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            LoadTableData();
        }

        private void LoadTableData()
        {
            using (var context = new LightSpeedDataContext())
            {
                
                CustomerCollection = new ObservableCollection<Customer>(context.Customers.ToList());
            }   
        }
    }
}
