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

        private DelegateCommand _openCustomerDetailsDialogCommand;
        public DelegateCommand OpenCustomerDetailsDialogCommand =>
            _openCustomerDetailsDialogCommand ?? (_openCustomerDetailsDialogCommand = new DelegateCommand(OpenCustomerDetailsDialog));

        private DelegateCommand _openCreateCustomerDialogCommand;
        public DelegateCommand OpenCreateCustomerDialogCommand =>
            _openCreateCustomerDialogCommand ?? (_openCreateCustomerDialogCommand = new DelegateCommand(OpenCreateCustomerDialog));

        private void OpenCreateCustomerDialog()
        {
            _dialogService.ShowDialog("CustomerDetailsDialog", null, null);
        }

        public void OpenCustomerDetailsDialog()
        {
            var customerId = SelectedItem.Id;

            _dialogService.ShowDialog("CustomerDetailsDialog", new DialogParameters($"IdentifierID={customerId}"), null);

            LoadTableData();
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
