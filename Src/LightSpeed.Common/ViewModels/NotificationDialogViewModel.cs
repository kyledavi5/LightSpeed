using System;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Common.Dialogs
{
    public class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        private string _message;

        public event Action<IDialogResult> RequestClose;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public NotificationDialogViewModel()
        {
            Title = "Notification";
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        public bool CanCloseDialog()
        {
            //throw new NotImplementedException();
            return true;
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }
    }
}
