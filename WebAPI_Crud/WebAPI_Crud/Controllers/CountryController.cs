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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _countryRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }
            
        }

        [HttpGet("{CountryId:int}")]
        public async Task<ActionResult<CountryModel>> GetCountry(int CountryId)
        {
            try
            {
                var result = await _countryRepository.GetCountry(CountryId);
                if (result==null)
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
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                if(country==null)
                {
                    return BadRequest();
                }
                var CreatedCountry = await _countryRepository.AddCountry(country);
                return CreatedAtAction(nameof(GetAll), new { id = country.CountryId }, country);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Country Name Already Exist");
            }
           


        }

        [HttpPut("{CountryId:int}")]
        public async Task<ActionResult<Country>> UpdateCountry(int CountryId,Country country)
        {
            try
            {
                if(CountryId != country.CountryId)
                {
                    return BadRequest("Id Mismatch");
                }
                var countryUpdate = await _countryRepository.GetCountry(CountryId);
                if (countryUpdate==null)
                {
                    return NotFound($"Country Id={CountryId} not Found");
                }

                 return await _countryRepository.UpdateCountry(country);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }
           
        
        }

        [HttpDelete("{CountryId:int}")]
        public async Task<ActionResult<Country>> DeleteCountry(int CountryId)
        {
            try
            {
                var countryDelete = await _countryRepository.GetCountry(CountryId);
                if (countryDelete == null)
                {
                    return NotFound($"Country Id={CountryId} not Found");
                }

                return await _countryRepository.DeleteCountry(CountryId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }
        }

       

    }
}
