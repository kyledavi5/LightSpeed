using LightSpeed.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Common.Services
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);

        Customer Get(int id);

        List<Customer> GetAll();

        void Find();
    }
}
