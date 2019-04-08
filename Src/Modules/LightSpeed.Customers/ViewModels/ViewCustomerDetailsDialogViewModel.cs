using LightSpeed.Common.Dialogs;
using LightSpeed.Data;
using Prism.Services.Dialogs;

namespace LightSpeed.Customers.Dialogs
{
    public class ViewCustomerDetailsDialogViewModel : DialogViewModelBase
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

        public ViewCustomerDetailsDialogViewModel()
        {
            CustomerFirstName = "Default";
            CustomerLastName = "Value";
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
            var result = new DialogResult();
            RaiseRequestClose(result);
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            Id = parameters.GetValue<int>("CustomerID");
            LoadRecordData(Id);
        }
    }
}
