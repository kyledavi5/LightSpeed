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
            }
        }

        protected override void CloseDialog(string parameter)
        {
            bool? result = null;

            if (parameter?.ToLower() == "true")
            {
                result = true;
            }
            else if (parameter?.ToLower() == "false")
            {
                result = false;
            }

            var dialogResult = new DialogResult();

            dialogResult.Parameters.Add("CustomerID", Id);
            dialogResult.Parameters.Add("CustomerFirstName", CustomerFirstName);
            dialogResult.Parameters.Add("CustomerLastName", CustomerLastName);
            RaiseRequestClose(dialogResult);
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            Id = parameters.GetValue<int>("CustomerID");
            LoadRecordData(Id);
        }
    }
}
