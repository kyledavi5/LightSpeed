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

        private DelegateCommand _openViewCustomerDetailsDialogCommand;
        public DelegateCommand OpenViewCustomerDetailsDialogCommand =>
            _openViewCustomerDetailsDialogCommand ?? (_openViewCustomerDetailsDialogCommand = new DelegateCommand(OpenCustomerDetailsDialog));

        private DelegateCommand _openNewCustomerDialogCommand;
        public DelegateCommand OpenNewCustomerDialogCommand =>
            _openNewCustomerDialogCommand ?? (_openNewCustomerDialogCommand = new DelegateCommand(OpenNewCustomerDialog));

        void OpenNewCustomerDialog()
        {
            _dialogService.ShowDialog("AddNewCustomerDialog",null, r =>
            {
                LoadTableData();     
            });
        }

        void OpenCustomerDetailsDialog()
        {
            var customerId = SelectedItem.Id;

            _dialogService.ShowDialog("UpdateCustomerDetailsDialog", new DialogParameters($"CustomerID={customerId}"), r => 
            {
                LoadTableData();
            });
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
