using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CountryModel, Country>().ReverseMap();
            CreateMap<StateModel, State>().ReverseMap();
            CreateMap<CityModel, City>().ReverseMap();
            CreateMap<CustomerModel, Customer>().ReverseMap();
        }
    }
}
