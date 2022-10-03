using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public CountryModel Country { get; set; }


    }


}
