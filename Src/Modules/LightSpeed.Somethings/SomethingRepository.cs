using LightSpeed.Common.Services;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Somethings
{
    public class SomethingRepository : ISomethingRepository
    {
        //TODO: Make this inherit from generic repository base class

        public Something FindById(int Id)
        {
            Something Something;

            using (var context = new LightSpeedDataContext())
            {
                Something = context.Somethings.Find(Id);
            }

            return Something;
        }

        public void Add(Something Something)
        {
            using (var context = new LightSpeedDataContext())
            {
                context.Somethings.Add(Something);
                context.SaveChanges();
            }
        }

        public void Remove(int Id)
        {
            using (var context = new LightSpeedDataContext())
            {
                Something Something = context.Somethings.Find(Id);

                context.Remove(Something);

                context.SaveChanges();
            }
        }

        public void Update(Something Something)
        {
            using (var context = new LightSpeedDataContext())
            {
                context.Update(Something);

                context.SaveChanges();
            }
        }

        public Something GetSomethingById(int id)
        {
            return null;
        }



        public List<Something> GetAll()
        {
            return null;
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public Something Get(int id)
        {
            throw new NotImplementedException();
        }

        

        Data.Models.Something ISomethingRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        List<Data.Models.Something> ISomethingRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
