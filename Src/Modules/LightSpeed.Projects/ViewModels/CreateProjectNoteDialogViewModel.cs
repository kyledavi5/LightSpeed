using System;
using System.Windows;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace LightSpeed.Projects.ViewModels
{
    public class CreateProjectNoteDialogViewModel : BindableBase, IDialogAware
    {
        private IProjectRepository _projectRepository;

        public event Action<IDialogResult> RequestClose;

        private ProjectNote _note;
        public ProjectNote Note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
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

        public CreateProjectNoteDialogViewModel(IProjectRepository ProjectRepository)
        {
           _projectRepository = ProjectRepository;
            Note = new ProjectNote();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters != null)
            {
                foreach (string parameterKey in parameters.Keys)
                {
                    if (parameterKey == "RecordIdentifier")
                    {
                        Note.ProjectId = parameters.GetValue<int>("RecordIdentifier");
                    }
                }
            }
            else
            {
                MessageBox.Show("No record identifier found");
            }
        }

        private void SaveRecordData()
        {
            using (var context = new LightSpeedDataContext())
            {
                Note.CreatedDate = DateTime.Now.ToShortDateString();
                context.ProjectNotes.Add(Note);

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
