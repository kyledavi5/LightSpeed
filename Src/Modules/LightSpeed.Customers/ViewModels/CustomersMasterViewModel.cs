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
    public class CustomersMasterViewModel : BindableBase, INavigationAware
    {
        private IDialogService _dialogService;

        //public ICollectionView Something { get; set; }

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
                using (var context = new LightSpeedDataContext())
                {
                    var customer = new Customer();
                    customer.FirstName = r.Parameters.GetValue<string>("CustomerFirstName");
                    customer.LastName = r.Parameters.GetValue<string>("CustomerLastName");
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                LoadTableData();     
            });
        }

        void OpenCustomerDetailsDialog()
        {
            var customerId = SelectedItem.Id;

            //todo add parameters that have the selected datagrid item in it so that the dialog's view model can query the database with an id of the selected object
            _dialogService.ShowDialog("UpdateCustomerDetailsDialog", new DialogParameters($"CustomerID={customerId}"), r => 
            {
                if (r.Result.HasValue)
                {
                    if (r.Result == true)
                    {
                        using (var context = new LightSpeedDataContext())
                        {
                            var customer = context.Customers.Find(r.Parameters.GetValue<int>("CustomerID"));
                            customer.FirstName = r.Parameters.GetValue<string>("CustomerFirstName");
                            customer.LastName = r.Parameters.GetValue<string>("CustomerLastName");
                            context.SaveChanges();
                        }
                        LoadTableData();
                    }
                }
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
                //Something = CollectionViewSource.GetDefaultView(CustomersItems);
            }   
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
