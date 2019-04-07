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

        public AddNewCustomerDialogViewModel()
        {
            
        }

        protected override void CloseDialog(string parameter)
        {
            var result = new DialogResult();
            result.Parameters.Add("CustomerFirstName", CustomerFirstName);
            result.Parameters.Add("CustomerLastName", CustomerLastName);

            RaiseRequestClose(result);
        }


        public override void OnDialogOpened(IDialogParameters parameters)
        {
            //Message = parameters.GetValue<string>("message");
        }
    }
}
