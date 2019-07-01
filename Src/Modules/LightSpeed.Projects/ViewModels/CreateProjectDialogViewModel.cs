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

        private Project _project;
        public Project Project
        {
            get { return _project; }
            set { SetProperty(ref _project, value); }
        }

        #region Data Bindings

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        

        #endregion

        #region Commands

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        #endregion

        public CreateProjectDialogViewModel(IProjectRepository ProjectRepository)
        {
           _projectRepository = ProjectRepository;
            Project = new Project();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        { 
                
        }

        private void SaveRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {

                context.Projects.Add(Project);

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
            
            if (boolParam.ToLower() == "ok")
            {
                SaveRecordData();
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
