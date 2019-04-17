using LightSpeed.Common.Services;
using LightSpeed.Data;
using LightSpeed.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        //TODO: Make this inherit from generic repository base class

        public Customer FindById(int Id)
        {
            Customer customer;

            using (var context = new LightSpeedDataContext())
            {
                customer = context.Customers.Find(Id);
            }

            return customer;
        }

        public void Add(Customer customer)
        {
            using (var context = new LightSpeedDataContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        public void Remove(int Id)
        {
            using (var context = new LightSpeedDataContext())
            {
                Customer customer = context.Customers.Find(Id);

                context.Remove(customer);

                context.SaveChanges();
            }
        }

        public void Update(Customer customer)
        {
            using (var context = new LightSpeedDataContext())
            {
                context.Update(customer);

                context.SaveChanges();
            }
        }

        public Customer GetCustomerById(int id)
        {
            return null;
        }



        public List<Customer> GetAll()
        {
            return null;
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
