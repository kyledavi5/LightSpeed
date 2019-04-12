using System;
using LightSpeed.Common.Dialogs;
using LightSpeed.Common.Enums;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Customers.Dialogs
{
    public class CustomerDetailsDialogViewModel : BindableBase, IDialogAware
    {
        private string _customerFirstName;
        public string CustomerFirstName
        {
            get { return _customerFirstName; }
            set { SetProperty(ref _customerFirstName, value); }
        }

        private string _customerLastName;
        public string CustomerLastName
        {
            get { return _customerLastName; }
            set { SetProperty(ref _customerLastName, value); }
        }

        private string _customerEmail;
        public string CustomerEmail
        {
            get { return _customerEmail; }
            set { SetProperty(ref _customerEmail, value); }
        }

        private string _customerAddress;
        public string CustomerAddress
        {
            get { return _customerAddress; }
            set { SetProperty(ref _customerAddress, value); }
        }

        private string _customerCity;
        public string CustomerCity
        {
            get { return _customerCity; }
            set { SetProperty(ref _customerCity, value); }
        }

        private string _customerState;
        public string CustomerState
        {
            get { return _customerState; }
            set { SetProperty(ref _customerState, value); }
        }

        private string _customerZipCode;
        public string CustomerZipCode
        {
            get { return _customerZipCode; }
            set { SetProperty(ref _customerZipCode, value); }
        }

        public string Title { get; set; }

        public int Identifier { get; set; }

        public DialogDataMode DataMode { get; set; }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        

        public CustomerDetailsDialogViewModel()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            string dataMode = parameters.GetValue<string>("DialogDataMode");

            switch (dataMode)
            {
                case "Create":
                    DataMode = DialogDataMode.Create;
                    break;
                case "Read":
                    DataMode = DialogDataMode.Read;
                    Identifier = parameters.GetValue<int>("IdentifierID");
                    LoadRecordData();
                    break;
                case "Update":
                    DataMode = DialogDataMode.Update;
                    Identifier = parameters.GetValue<int>("IdentifierID");
                    LoadRecordData();
                    break;
                case "UpdateDelete":
                    DataMode = DialogDataMode.UpdateDelete;
                    Identifier = parameters.GetValue<int>("IdentifierID");
                    LoadRecordData();
                    break;
                default:
                    // throw exeception
                    break;
            }
        }

        event Action<IDialogResult> IDialogAware.RequestClose
        {
            add
            {
                
            }

            remove
            {
                
            }
        }

        public event Action<IDialogResult> RequestClose;

        private void LoadRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                Customer customer = context.Customers.Find(Identifier);

                CustomerFirstName = customer.FirstName;
                CustomerLastName = customer.LastName;
                CustomerEmail = customer.Email;
                CustomerAddress = customer.Address;
                CustomerCity = customer.City;
                CustomerState = customer.State;
                CustomerZipCode = customer.ZipCode;
            }
        }

        private void SaveRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                Customer customer = new Customer();

                customer.FirstName = CustomerFirstName;
                customer.LastName = CustomerLastName;
                customer.Email = CustomerEmail;
                customer.Address = CustomerAddress;
                customer.City = CustomerCity;
                customer.State = CustomerState;
                customer.ZipCode = CustomerZipCode;

                context.Customers.Add(customer);

                context.SaveChanges();
            }
        }

        private void UpdateRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                Customer customer = context.Customers.Find(Identifier);

                customer.FirstName = CustomerFirstName;
                customer.LastName = CustomerLastName;
                customer.Email = CustomerEmail;
                customer.Address = CustomerAddress;
                customer.City = CustomerCity;
                customer.State = CustomerState;
                customer.ZipCode = CustomerZipCode;

                context.SaveChanges();
            }
        }

        public void DeleteDataCloseDialog(string confirmedDelete)
        {
            
        }

        protected void DeleteRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                Customer customer = context.Customers.Find(Identifier);

                context.Remove(customer);

                context.SaveChanges();
            }
        }

        protected void CloseDialog(string boolParam)
        {
            bool buttonResult;

            if (boolParam.ToLower() == "true")
            {
                buttonResult = true;
            }
            else
            {
                buttonResult = false;
            }



            var dialogResult = new DialogResult(buttonResult);
        }

        

        public void RaiseRequestClose(IDialogResult dialogResult)
        {
            if(dialogResult.Result == true)
            {
                if (DataMode == DialogDataMode.Create)
                {
                    SaveRecordData();
                }
                if (DataMode == DialogDataMode.Update)
                {
                    UpdateRecordData();
                }
                if (DataMode == DialogDataMode.UpdateDelete)
                {
                    DeleteRecordData();
                }
            }

            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }
    }
}
