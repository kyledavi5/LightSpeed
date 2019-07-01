using System;
using System.Windows;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Projects.ViewModels
{
    public class ProjectDetailsDialogViewModel : BindableBase, IDialogAware
    {
        private IProjectRepository _projectRepository;

        public event Action<IDialogResult> RequestClose;

        private Project _project;
        public Project Project
        {
            get { return _project; }
            set { SetProperty(ref _project, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private DelegateCommand _deleteRecordCommand;
        public DelegateCommand DeleteRecordCommand => _deleteRecordCommand ?? (_deleteRecordCommand = new DelegateCommand(DeleteRecord));

        public ProjectDetailsDialogViewModel(IProjectRepository ProjectRepository)
        {
            _projectRepository = ProjectRepository;
            Project = new Project();

        }

        public void DeleteRecord()
        {
            //TODO: Display a confirmation dialog that prompts the user for record deletion confirmation

            //TODO: write delete record confirmation logic
                // get the results of the confirmation from the command parameter (true/false)
                // assign a bool value to a result variable
                // evaluate the result variable and if true call the delete record command   
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
