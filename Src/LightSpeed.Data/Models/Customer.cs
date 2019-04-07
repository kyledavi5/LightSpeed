﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightSpeed.Data.Models
{
    public class Customer : BindableBase
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
