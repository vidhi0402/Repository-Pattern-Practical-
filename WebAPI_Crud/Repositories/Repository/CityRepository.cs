using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http;
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
    public class CityRepository : ICityRepository
    {
        private readonly CrudDBContext _Context;
        private readonly IMapper _mapper;

        public CityRepository(CrudDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }

        public async Task<City> AddCity(City city)
        {
            if (_Context.City.Any(r => r.CityName == city.CityName))
            {
                throw new Exception();
            }
            else if (_Context.State.Any(x => x.StateId == city.StateId))
            {
                var result = await _Context.City.AddAsync(city);
                await _Context.SaveChangesAsync();
                return result.Entity;

            }
            else
            {
                throw new NotImplementedException();
            }

        }

        public async Task<City> DeleteCity(int CityId)
        {
            var result = await _Context.City.Where(a => a.CityId == CityId).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.City.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CityModel>> GetAll()
        {
            var records = await _Context.City.Include(a => a.State).ThenInclude(x => x.Country).ToListAsync();
            return _mapper.Map<List<CityModel>>(records);
        }
    

        public async Task<CityModel> GetCity(int CityId)
        {
            var Cities = await _Context.City.Include(a => a.State).ThenInclude(x => x.Country).FirstOrDefaultAsync(a => a.CityId == CityId);
            return _mapper.Map<CityModel>(Cities);
        }

        public async Task<City> UpdateCity(City city)
        {
            var result = await _Context.City.FirstOrDefaultAsync(a => a.CityId == city.CityId);
            if (result != null)
            {
                result.CityName = city.CityName;
                result.StateId = city.StateId;
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
    

}
