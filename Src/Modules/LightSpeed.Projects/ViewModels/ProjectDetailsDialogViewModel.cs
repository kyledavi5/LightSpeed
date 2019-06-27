using System;
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

        private int _recordIdentifier;
        public int RecordIdentifier
        {
            get { return _recordIdentifier; }
            set { SetProperty(ref _recordIdentifier, value); }
        }

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

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private DelegateCommand _deleteRecordCommand;
        public DelegateCommand DeleteRecordCommand => _deleteRecordCommand ?? (_deleteRecordCommand = new DelegateCommand(DeleteRecord));

        public ProjectDetailsDialogViewModel(IProjectRepository ProjectRepository)
        {
            _projectRepository = ProjectRepository;
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
            foreach (var parameterKey in parameters.Keys)
            {
                if(parameterKey == "RecordIdentifier")
                {
                    RecordIdentifier = parameters.GetValue<int>("RecordIdentifier");
                }
            }            
        }

        private void LoadRecordData()
        {
            Project project = new Project();
            //Something = _somethingRepository //GetSomethingById(RecordIdentifier);
            
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
            bool buttonResult;

            if (boolParam.ToLower() == "true")
            {
                buttonResult = true;
            }
            else
            {
                buttonResult = false;
            }

            //var dialogResult = new DialogResult(buttonResult);

            //RaiseRequestClose(dialogResult);
        }

        public void RaiseRequestClose(IDialogResult dialogResult)
        {
            //if(dialogResult.Result == true)
            //{
            //    // some record action
            //}

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
