using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public StateModel State { get; set; }

       

    }
}
