﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
   public class CustomerModel
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
         public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Pincode { get; set; }
        public CityModel City { get; set; }
    }
}
