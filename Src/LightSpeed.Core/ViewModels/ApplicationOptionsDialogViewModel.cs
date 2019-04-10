using LightSpeed.Common.Dialogs;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace LightSpeed.Core.Dialogs
{
    public class ApplicationOptionsDialogViewModel : DialogViewModelBase
    {
        IRegionManager _regionManager;

        private DelegateCommand<string> _navigate;
        public DelegateCommand<string> Navigate =>
            _navigate ?? (_navigate = new DelegateCommand<string>(ExecuteNavigate));

        void ExecuteNavigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                _regionManager.RequestNavigate("ApplicationOptionsContent", navigatePath);
            }
        }

        public ApplicationOptionsDialogViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        protected override void CloseDialog(string boolParam)
        {
            bool buttonResult = false;

            if (boolParam.ToLower() == "true")
            {
                buttonResult = true;
                //SaveToDatabase();
            }

            var dialogResult = new DialogResult(buttonResult);

            RaiseRequestClose(dialogResult);
        }

        public void ValidateData()
        {

        }

        public void SaveToDatabase()
        {
            //using (var context = new LightSpeedDataContext())
            //{
                
            //}
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {


            //Message = parameters.GetValue<string>("message");
        }
    }
}
