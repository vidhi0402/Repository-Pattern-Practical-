using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositories.Services
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryModel>> GetAll();
        Task<CountryModel> GetCountry(int CountryId);
        Task<Country> AddCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        Task<Country> DeleteCountry(int CountryId);

    }
}
