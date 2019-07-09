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

        private ObservableCollection<Project> _projectsCollection;
        public ObservableCollection<Project> ProjectsCollection
        {
            get { return _projectsCollection; }
            set { SetProperty(ref _projectsCollection, value); }
        }

        private DelegateCommand _openProjectDetailsDialogCommand;
        public DelegateCommand OpenProjectDetailsDialogCommand =>
            _openProjectDetailsDialogCommand ?? (_openProjectDetailsDialogCommand = new DelegateCommand(OpenProjectDetailsDialog));

        private DelegateCommand _openCreateProjectDialogCommand;
        public DelegateCommand OpenCreateProjectDialogCommand =>
            _openCreateProjectDialogCommand ?? (_openCreateProjectDialogCommand = new DelegateCommand(OpenCreateProjectDialog));

        private void OpenCreateProjectDialog()
        {
            _dialogService.ShowDialog("CreateProjectDialog", null, r => { LoadTableData(); });
        }

        public void OpenProjectDetailsDialog()
        {
            

            _dialogService.ShowDialog("ProjectDetailsDialog", new DialogParameters($"RecordIdentifier={SelectedProjectRecord.Id}"), r => { LoadTableData(); });

            LoadTableData();
        }

        public ProjectsMasterViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            SelectedProjectRecord = new Project();
            LoadTableData();
        }

        private void LoadTableData()
        {
            using (var context = new LightSpeedDataContext())
            {
                ProjectsCollection = new ObservableCollection<Project>(context.Projects.ToList());
            }
        }
    }
}
