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
    public class StateRepository : IStateRepository
    {        
            private readonly CrudDBContext _Context;
            private readonly IMapper _mapper;
            public StateRepository(CrudDBContext Context, IMapper mapper)
            {
                _Context = Context;
                _mapper = mapper;
            }

            public async Task<State> AddState(State state)
            {
            if (_Context.State.Any(r => r.StateName == state.StateName))
            {
                throw new Exception();
            }
            else if (_Context.Country.Any(x => x.CountryId == state.CountryId))
            {
               var result = await _Context.State.AddAsync(state);
                await _Context.SaveChangesAsync();
                return result.Entity;
                
            }
            else
            {
                throw new NotImplementedException();
            }
           
            }

            public async Task<State> DeleteState(int StateId)
            {
            var result = await _Context.State.Where(a => a.StateId == StateId).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.State.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
            }

            public async Task<IEnumerable<StateModel>> GetAll()
            {
                var records = await _Context.State.Include(a=>a.Country).ToListAsync();
                return _mapper.Map<List<StateModel>>(records);
            }

            public async Task<StateModel> GetState(int StateId)
            {
            var states = await _Context.State.Include(a => a.Country).FirstOrDefaultAsync(a => a.StateId == StateId);
            return _mapper.Map<StateModel>(states);
            }
    

            public async Task<State> UpdateState(State state)
            {
            var result = await _Context.State.FirstOrDefaultAsync(a => a.StateId == state.StateId);
            if (result != null)
            {
                result.StateName = state.StateName;
                result.CountryId = state.CountryId;
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
            }
    }
}
