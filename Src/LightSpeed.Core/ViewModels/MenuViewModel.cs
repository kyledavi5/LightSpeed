using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSpeed.Core.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private DelegateCommand _openApplicationOptionsDialog;
        public DelegateCommand OpenApplicationOptionsDialog =>
            _openApplicationOptionsDialog ?? (_openApplicationOptionsDialog = new DelegateCommand(ExecuteOpenApplicationOptionsDialog));

        void ExecuteOpenApplicationOptionsDialog()
        {
            _dialogService.ShowDialog("ApplicationOptionsDialog", null, r =>
            {
                //LoadTableData();
            });
        }

        public MenuViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
    }
}
