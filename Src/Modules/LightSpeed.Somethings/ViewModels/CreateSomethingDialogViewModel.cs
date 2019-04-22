using System;
using LightSpeed.Common.Dialogs;
using LightSpeed.Common.Services;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Somethings.Dialogs
{
    public class CreateSomethingDialogViewModel : BindableBase, IDialogAware
    {
        private ISomethingRepository _somethingRepository;

        public event Action<IDialogResult> RequestClose;

        private int _recordIdentifier;
        public int RecordIdentifier
        {
            get { return _recordIdentifier; }
            set { SetProperty(ref _recordIdentifier, value); }
        }

        #region Data Bindings

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _somethingName;
        public string SomethingName
        {
            get { return _somethingName; }
            set { SetProperty(ref _somethingName, value); }
        }

        private string _somethingDescription;
        public string SomethingDescription
        {
            get { return _somethingDescription; }
            set { SetProperty(ref _somethingDescription, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        #endregion

        public CreateSomethingDialogViewModel(ISomethingRepository SomethingRepository)
        {
            _somethingRepository = SomethingRepository;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        { 
                
        }

        private void SaveRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                var something = new Something();

                something.Name = SomethingName;

                context.Somethings.Add(something);

                context.SaveChanges();
                
            }
        }

        public bool CanCloseDialog()
        {
            return true;
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
                // some record action
            }

            RequestClose?.Invoke(dialogResult);
        }

        

        public void OnDialogClosed()
        {
           
        }
    }
}
