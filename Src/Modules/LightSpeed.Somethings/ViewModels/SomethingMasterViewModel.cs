using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightSpeed.Data;
using System.ComponentModel;
using System.Windows.Data;
using LightSpeed.Common.Dialogs;

namespace LightSpeed.Somethings.ViewModels
{
    public class SomethingsMasterViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private Something _selectedSomethingRecord;
        public Something SelectedSomethingRecord
        {
            get { return _selectedSomethingRecord; }
            set { SetProperty(ref _selectedSomethingRecord, value); }
        }

        private ObservableCollection<Something> _somethingCollection;
        public ObservableCollection<Something> SomethingCollection
        {
            get { return _somethingCollection; }
            set { SetProperty(ref _somethingCollection, value); }
        }

        private DelegateCommand _openSomethingDetailsDialogCommand;
        public DelegateCommand OpenSomethingDetailsDialogCommand =>
            _openSomethingDetailsDialogCommand ?? (_openSomethingDetailsDialogCommand = new DelegateCommand(OpenSomethingDetailsDialog));

        private DelegateCommand _openCreateSomethingDialogCommand;
        public DelegateCommand OpenCreateSomethingDialogCommand =>
            _openCreateSomethingDialogCommand ?? (_openCreateSomethingDialogCommand = new DelegateCommand(OpenCreateSomethingDialog));

        private void OpenCreateSomethingDialog()
        {
            _dialogService.ShowDialog("CreateSomethingDialog", null, null);
        }

        public void OpenSomethingDetailsDialog()
        {
            var selectedRecordId = SelectedSomethingRecord.Id;

            _dialogService.ShowDialog("SomethingDetailsDialog", new DialogParameters($"IdentifierID={selectedRecordId}"), null);

            LoadTableData();
        }

        public SomethingsMasterViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            LoadTableData();
        }

        private void LoadTableData()
        {
            using (var context = new LightSpeedDataContext())
            {
                SomethingCollection = new ObservableCollection<Something>(context.Somethings.ToList());
            }   
        }
    }
}
