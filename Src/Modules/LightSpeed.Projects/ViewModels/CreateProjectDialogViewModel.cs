using System;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Projects.ViewModels
{
    public class CreateProjectDialogViewModel : BindableBase, IDialogAware
    {
        private IProjectRepository _projectRepository;

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

        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set { SetProperty(ref _projectName, value); }
        }

        private string _projectDescription;
        public string ProjectDescription
        {
            get { return _projectDescription; }
            set { SetProperty(ref _projectDescription, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        #endregion

        public CreateProjectDialogViewModel(IProjectRepository ProjectRepository)
        {
           _projectRepository = ProjectRepository;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        { 
                
        }

        private void SaveRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                var project = new Project();

                project.Name = ProjectName;

                context.Projects.Add(project);

                context.SaveChanges();
                
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        protected void CloseDialog(string boolParam)
        {
            DialogResult dialogResult;
            
            if (boolParam.ToLower() == "OK")
            {
                dialogResult = new DialogResult(ButtonResult.OK);
            }
            else
            {
                dialogResult = new DialogResult(ButtonResult.Cancel);

            }

            RequestClose?.Invoke(dialogResult);
        }

        public void OnDialogClosed()
        {
           
        }
    }
}
