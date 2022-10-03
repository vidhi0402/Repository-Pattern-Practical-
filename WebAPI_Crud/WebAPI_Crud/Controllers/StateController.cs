using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace WebAPI_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
       
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var records = await _stateRepository.GetAll();
            return Ok(records);
        }

        [HttpGet("{StateId:int}")]
        public async Task<ActionResult<StateModel>> GetState(int StateId)
        {
            try
            {
                var result = await _stateRepository.GetState(StateId);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<State>> CreateState(State state)
        {
            try
            {
                if (state == null)
                {
                    return BadRequest();
                }
                var CreatedState = await _stateRepository.AddState(state);
                return CreatedAtAction(nameof(GetAll), new { id = state.StateId }, state);


            }
            catch (NotImplementedException)
            {
                return StatusCode(StatusCodes.Status409Conflict, "CountryId doesn't Exist");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status409Conflict, "State Name Already Exist");
            }
            
          
        }

        [HttpPut("{StateId:int}")]
        public async Task<ActionResult<State>> UpdateState(int StateId, State state)
        {
            try
            {
                if (StateId != state.StateId)
                {
                    return BadRequest("Id Mismatch");
                }
                var stateUpdate = await _stateRepository.GetState(StateId);
                if (stateUpdate == null)
                {
                    return NotFound($"State Id={StateId} not Found");
                }

                return await _stateRepository.UpdateState(state);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }


        }

        [HttpDelete("{StateId:int}")]
        public async Task<ActionResult<State>> DeleteState(int StateId)
        {
            try
            {
                var stateDelete = await _stateRepository.GetState(StateId);
                if (stateDelete == null)
                {
                    return NotFound($"State Id={StateId} not Found");
                }

                return await _stateRepository.DeleteState(StateId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }
        }

    }
}
