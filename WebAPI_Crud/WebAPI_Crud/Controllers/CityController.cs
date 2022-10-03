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
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            var records = await _cityRepository.GetAll();
            return Ok(records);
        }

        [HttpGet("{CityId:int}")]
        public async Task<ActionResult<CityModel>> GetCity(int CityId)
        {
            try
            {
                var result = await _cityRepository.GetCity(CityId);
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
        public async Task<ActionResult<City>> CreateCity(City city)
        {
            try
            {
                if (city == null)
                {
                    return BadRequest();
                }
                var CreatedCity = await _cityRepository.AddCity(city);
                return CreatedAtAction(nameof(GetAll), new { id = city.CityId }, city);


            }
            catch (NotImplementedException)
            {
                return StatusCode(StatusCodes.Status409Conflict, "StateId doesn't Exist");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status409Conflict, "City Name Already Exist");
            }


        }

        [HttpPut("{CityId:int}")]
        public async Task<ActionResult<City>> UpdateCity(int CityId, City city)
        {
            try
            {
                if (CityId != city.CityId)
                {
                    return BadRequest("Id Mismatch");
                }
                var cityUpdate = await _cityRepository.GetCity(CityId);
                if (cityUpdate == null)
                {
                    return NotFound($"City Id={CityId} not Found");
                }

                return await _cityRepository.UpdateCity(city);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }

        }

        [HttpDelete("{CityId:int}")]
        public async Task<ActionResult<City>> DeleteCity(int CityId)
        {
            try
            {
                var cityDelete = await _cityRepository.GetCity(CityId);
                if (cityDelete == null)
                {
                    return NotFound($"City Id={CityId} not Found");
                }

                return await _cityRepository.DeleteCity(CityId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }
        }


    }
}
