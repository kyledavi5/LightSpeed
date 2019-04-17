using LightSpeed.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Common.Services
{
    public interface ISomethingRepository
    {
        void Add(Something Something);

        Something Get(int id);

        List<Something> GetAll();

        void Find();
    }
}
