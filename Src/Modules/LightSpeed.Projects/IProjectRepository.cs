using LightSpeed.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Projects
{
    public interface IProjectRepository
    {
        Project FindById(int id);
    }
}
