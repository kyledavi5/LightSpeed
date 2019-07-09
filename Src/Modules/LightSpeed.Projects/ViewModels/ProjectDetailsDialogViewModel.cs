using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Projects.ViewModels
{
    public class ProjectDetailsDialogViewModel : BindableBase, IDialogAware
    {
        private IProjectRepository _projectRepository;

        IDialogService _dialogService;

        public event Action<IDialogResult> RequestClose;

        private Project _project;
        public Project Project
        {
            get { return _project; }
            set { SetProperty(ref _project, value); }
        }

        private ProjectNote _selectedNote;
        public ProjectNote SelectedNote
        {
            get { return _selectedNote; }
            set { SetProperty(ref _selectedNote, value); }
        }

        private DelegateCommand _deleteNoteCommand;
        public DelegateCommand DeleteNoteCommand =>
            _deleteNoteCommand ?? (_deleteNoteCommand = new DelegateCommand(ExecuteDeleteNoteCommand));

        void ExecuteDeleteNoteCommand()
        {
            using (var context = new LightSpeedDataContext())
            {
                var note = context.ProjectNotes.Find(SelectedNote.Id);
                context.ProjectNotes.Remove(note);
                context.SaveChanges();
                LoadRecordData(Project.Id);
            }
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<ProjectNote> _projectNotes;
        public ObservableCollection<ProjectNote> ProjectNotes
        {
            get { return _projectNotes; }
            set { SetProperty(ref _projectNotes, value); }
        }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private DelegateCommand _addProjectNoteCommand;
        public DelegateCommand AddProjectNoteCommand => _addProjectNoteCommand ?? (_addProjectNoteCommand = new DelegateCommand(ExecuteAddProjectNoteCommand));

        private DelegateCommand _deleteRecordCommand;
        public DelegateCommand DeleteRecordCommand => _deleteRecordCommand ?? (_deleteRecordCommand = new DelegateCommand(DeleteRecord));

        public ProjectDetailsDialogViewModel(IProjectRepository ProjectRepository, IDialogService dialogService)
        {
            _projectRepository = ProjectRepository;
            _dialogService = dialogService;
            Project = new Project();
            SelectedNote = new ProjectNote();
        }

        private void ExecuteAddProjectNoteCommand()
        {
            _dialogService.ShowDialog("CreateProjectNoteDialog", new DialogParameters($"RecordIdentifier={Project.Id}"), r => { LoadRecordData(Project.Id); });

            
        }

        public void DeleteRecord()
        {
            //TODO: Display a confirmation dialog that prompts the user for record deletion confirmation
            using (var context = new LightSpeedDataContext())
            {
                context.Projects.Remove(Project);
                context.SaveChanges();
            }
            CloseDialog("false");
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters != null)
            {
                foreach (string parameterKey in parameters.Keys)
                {
                    if (parameterKey == "RecordIdentifier")
                    {
                        LoadRecordData(parameters.GetValue<int>("RecordIdentifier"));
                    }
                }         
            }
            else
            {
                MessageBox.Show("No record identifier found");
            }
        }

        private void LoadRecordData(int recordIdentifier)
        {
            Project = _projectRepository.FindById(recordIdentifier);
            using (var context = new LightSpeedDataContext())
            {
                ProjectNotes = new ObservableCollection<ProjectNote>(context.ProjectNotes.ToList());
            }
            
            //ProjectName = Project.Name;
            //ProjectDescription = Project.Description;
        }

        private void SaveRecordData()
        {
            
        }

        private void UpdateRecordData()
        {
            //TODO: write logic for determining if the user requesting the record update is authorized for the action

            //TODO: determine if any of the fields have changes as a way to see if the update method needs to be called
        }

        protected void CloseDialog(string boolParam)
        {
            DialogResult dialogResult;

            if (boolParam.ToLower() == "ok")
            {
                dialogResult = new DialogResult(ButtonResult.OK);
            }
            else
            {
                dialogResult = new DialogResult(ButtonResult.Cancel);

            }

            RequestClose?.Invoke(dialogResult);
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
