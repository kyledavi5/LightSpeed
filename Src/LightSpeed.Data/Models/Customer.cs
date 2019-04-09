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

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
