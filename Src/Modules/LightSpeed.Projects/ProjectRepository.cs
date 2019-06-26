using LightSpeed.Data;
using LightSpeed.Data.Models;
using System;
using System.Collections.Generic;

namespace LightSpeed.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        //TODO: Make this inherit from generic repository base class

        public Project FindById(int Id)
        {
            Project Something;

            using (var context = new LightSpeedDataContext())
            {
                Something = context.Projects.Find(Id);
            }

            return Something;
        }

        public void Add(Project project)
        {
            using (var context = new LightSpeedDataContext())
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        public void Remove(int Id)
        {
            using (var context = new LightSpeedDataContext())
            {
                Project project = context.Projects.Find(Id);

                context.Remove(project);

                context.SaveChanges();
            }
        }

        public void Update(Project project)
        {
            using (var context = new LightSpeedDataContext())
            {
                context.Update(project);

                context.SaveChanges();
            }
        }

        public Project GetProjectById(int id)
        {
            return null;
        }



        public List<Project> GetAll()
        {
            return null;
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
