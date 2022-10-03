using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositories.Services
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityModel>> GetAll();
        Task<CityModel> GetCity(int CityId);
        Task<City> AddCity(City city);
        Task<City> UpdateCity(City city);
        Task<City> DeleteCity(int CityId);

    }
}
