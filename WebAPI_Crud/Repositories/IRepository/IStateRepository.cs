using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositories.Services
{
   public interface IStateRepository
    {
        Task<IEnumerable<StateModel>> GetAll();
        Task<StateModel> GetState(int StateId);
        Task<State> AddState(State state);
        Task<State> UpdateState(State state);
        Task<State> DeleteState(int StateId);

    }
}
