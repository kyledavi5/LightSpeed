using System;

//using LightSpeed.Data;
//using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace LightSpeed.Core.Dialogs
{
    public class ApplicationOptionsDialogViewModel : BindableBase, IDialogAware
    {
        IRegionManager _regionManager;

        private DelegateCommand<string> _navigate;

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> Navigate =>
            _navigate ?? (_navigate = new DelegateCommand<string>(ExecuteNavigate));

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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

        protected void CloseDialog(string boolParam)
        {
            bool buttonResult = false;

            if (boolParam.ToLower() == "true")
            {
                buttonResult = true;
                //SaveToDatabase();
            }

            //var dialogResult = new DialogResult(buttonResult);

            //RaiseRequestClose(dialogResult);
        }

        private void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose.Invoke(dialogResult);
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

        public void OnDialogOpened(IDialogParameters parameters)
        {


            //Message = parameters.GetValue<string>("message");
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
