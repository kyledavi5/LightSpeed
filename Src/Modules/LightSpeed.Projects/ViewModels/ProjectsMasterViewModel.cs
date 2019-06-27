using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Linq;
using LightSpeed.Data;

namespace LightSpeed.Projects.ViewModels
{
    public class ProjectsMasterViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private Project _selectedProjectRecord;
        public Project SelectedProjectRecord
        {
            get { return _selectedProjectRecord; }
            set { SetProperty(ref _selectedProjectRecord, value); }
        }

        private ObservableCollection<Project> _projectCollection;
        public ObservableCollection<Project> ProjectCollection
        {
            get { return _projectCollection; }
            set { SetProperty(ref _projectCollection, value); }
        }

        private DelegateCommand _openProjectDetailsDialogCommand;
        public DelegateCommand OpenProjectDetailsDialogCommand =>
            _openProjectDetailsDialogCommand ?? (_openProjectDetailsDialogCommand = new DelegateCommand(OpenProjectDetailsDialog));

        private DelegateCommand _openCreateProjectDialogCommand;
        public DelegateCommand OpenCreateProjectDialogCommand =>
            _openCreateProjectDialogCommand ?? (_openCreateProjectDialogCommand = new DelegateCommand(OpenCreateProjectDialog));

        private void OpenCreateProjectDialog()
        {
            _dialogService.ShowDialog("CreateProjectDialog", null, null);
        }

        public void OpenProjectDetailsDialog()
        {
            var selectedRecordId = SelectedProjectRecord.Id;

            _dialogService.ShowDialog("ProjectDetailsDialog", new DialogParameters($"IdentifierID={selectedRecordId}"), null);

            LoadTableData();
        }

        public ProjectsMasterViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            LoadTableData();
        }

        private void LoadTableData()
        {
            //using (var context = new LightSpeedDataContext())
            //{
            //    ProjectCollection = new ObservableCollection<Project>(context.Projects.ToList());
            //}   
        }
    }
}
