using LightSpeed.Common.Dialogs;
using LightSpeed.Data;
using Prism.Services.Dialogs;

namespace LightSpeed.Customers.Dialogs
{
    public class UpdateCustomerDetailsDialogViewModel : DialogViewModelBase
    {

        protected int Id { get; set; }

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

        public UpdateCustomerDetailsDialogViewModel()
        {
            
        }

        private void LoadRecordData(int id)
        {
            using (var context = new LightSpeedDataContext())
            {
                var customer = context.Customers.Find(id);

                CustomerFirstName = customer.FirstName;
                CustomerLastName = customer.LastName;
                CustomerEmail = customer.Email;
                CustomerAddress = customer.Address;
                CustomerCity = customer.City;
                CustomerState = customer.State;
                CustomerZipCode = customer.ZipCode;
            }
        }

        protected override void CloseDialog(string boolParam)
        {

            bool buttonResult = false;

            if (boolParam.ToLower() == "true")
            {
                buttonResult = true;
                SaveToDatabase();
            }

            var dialogResult = new DialogResult(buttonResult);

            

            RaiseRequestClose(dialogResult);
        }

        private void ValidateData()
        {

        }

        private void SaveToDatabase()
        {
            using (var context = new LightSpeedDataContext())
            {
                var customer = context.Customers.Find(Id);

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

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            Id = parameters.GetValue<int>("CustomerID");
            LoadRecordData(Id);
        }
    }
}
