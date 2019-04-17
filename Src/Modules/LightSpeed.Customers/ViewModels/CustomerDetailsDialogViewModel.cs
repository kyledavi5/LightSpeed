using System;
using LightSpeed.Common.Dialogs;
using LightSpeed.Common.Services;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Customers.Dialogs
{
    public class CustomerDetailsDialogViewModel : BindableBase, IDialogAware
    {

        private int _recordIdentifier;
        public int RecordIdentifier
        {
            get { return _recordIdentifier; }
            set { SetProperty(ref _recordIdentifier, value); }
        }



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

        private object _customerRepository;
        public string Title { get; set; }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        

        public event Action<IDialogResult> RequestClose;

        private DelegateCommand _DeleteRecordCommand;
        public DelegateCommand DeleteRecordCommand => _DeleteRecordCommand ?? (_DeleteRecordCommand = new DelegateCommand(DeleteRecord));

        public void DeleteRecord()
        {
            //TODO: Display a confirmation dialog that prompts the user for record deletion confirmation

            // get the results of the confirmation from the command parameter (true/false)

            // assign a bool value to a result variable

            // evaluate the results of the bool variable and if true call the delete record command   
        }

        public CustomerDetailsDialogViewModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        { 
            foreach (var parameterKey in parameters.Keys)
            {
                if(parameterKey == "RecordIdentifier")
                {
                    RecordIdentifier = parameters.GetValue<int>("RecordIdentifier");
                }
            }            
        }


        private void LoadRecordData()
        {
            Customer customer = new Customer();
            //customer = _customerRepository.GetCustomerById(recordIdentifier);
            
            CustomerFirstName = customer.FirstName;
            CustomerLastName = customer.LastName;

        }

        private void SaveRecordData()
        {
            
        }

        private void UpdateRecordData()
        {
            //TODO: determine if the user is authorized to perform and a record update

            //TODO: determine if any of the fields have changes as a way to see if the update method needs to be called

            //TODO: Implement CustomerRepository instead
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

            RaiseRequestClose(dialogResult);
        }

        public void RaiseRequestClose(IDialogResult dialogResult)
        {
            if(dialogResult.Result == true)
            {
                
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
