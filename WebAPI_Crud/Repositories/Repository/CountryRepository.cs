using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositories.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CrudDBContext _Context;
        private readonly IMapper _mapper;
        public CountryRepository(CrudDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }
        public async Task<Country> AddCountry(Country country)
        {
            if (_Context.Country.Any(r => r.CountryName == country.CountryName))
            {
                throw new Exception();
            }
            var result = await _Context.Country.AddAsync(country);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Country> DeleteCountry(int CountryId)
        {
            var result = await _Context.Country.Where(a=>a.CountryId== CountryId).FirstOrDefaultAsync();
            if (result!=null)
            {
                _Context.Country.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CountryModel>> GetAll()
        {
            var records = await _Context.Country.ToListAsync();
            return _mapper.Map<List<CountryModel>>(records);
        }

        public async Task<CountryModel> GetCountry(int CountryId)
        {
            var country = await _Context.Country.FirstOrDefaultAsync(a => a.CountryId == CountryId);
            return _mapper.Map<CountryModel>(country);
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var result = await _Context.Country.FirstOrDefaultAsync(a => a.CountryId == country.CountryId);
            if (result!=null)
            {
                result.CountryName = country.CountryName;
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
