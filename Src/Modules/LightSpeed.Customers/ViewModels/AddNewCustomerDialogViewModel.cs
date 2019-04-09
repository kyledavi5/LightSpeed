using LightSpeed.Common.Dialogs;
using Prism.Services.Dialogs;

namespace LightSpeed.Customers.Dialogs
{
    public class AddNewCustomerDialogViewModel : DialogViewModelBase
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

        public AddNewCustomerDialogViewModel()
        {
            
        }

        protected override void CloseDialog(string boolParam)
        {
            bool buttonResult = false;

            if (boolParam.ToLower() == "true")
            {
                buttonResult = true;
            }

            var dialogResult = new DialogResult(buttonResult);

            
            dialogResult.Parameters.Add("CustomerFirstName", CustomerFirstName);
            dialogResult.Parameters.Add("CustomerLastName", CustomerLastName);
            dialogResult.Parameters.Add("CustomerEmail", CustomerEmail);
            dialogResult.Parameters.Add("CustomerAddress", CustomerAddress);
            dialogResult.Parameters.Add("CustomerCity", CustomerCity);
            dialogResult.Parameters.Add("CustomerState", CustomerState);
            dialogResult.Parameters.Add("CustomerZipCode", CustomerZipCode);


            RaiseRequestClose(dialogResult);
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
        }
    }
}
