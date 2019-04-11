using LightSpeed.Common.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace LightSpeed.Common.Dialogs
{
    public class DataDialogViewModelBase : BindableBase, IDialogAware
    {
        public int Identifier { get; set; }

        public DialogDataMode DataMode { get; private set; }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual void CloseDialog(string boolParam)
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

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
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
                default:
                    // throw exeception
                    break;
            }
        }

        protected virtual void LoadRecordData()
        {

        }
    }
}
