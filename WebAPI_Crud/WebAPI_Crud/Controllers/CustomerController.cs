using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace WebAPI_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            var records = await _customerRepository.GetAll();
            return Ok(records);
        }

        [HttpGet("{Id:Guid}")]
        public async Task<ActionResult<CustomerModel>> GetCustomer(Guid Id)
        {
            try
            {
                var result = await _customerRepository.GetCustomer(Id);
                if(result == null)
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
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            try
            {
                if(customer == null)
                {
                    return BadRequest();
                }
                var CreatedCustomer = await _customerRepository.AddCustomer(customer);
                return CreatedAtAction(nameof(GetAll), new { id = customer.Id }, customer);
            }
            catch (NotImplementedException)
            {
                return StatusCode(StatusCodes.Status409Conflict, "CityId doesn't Exist");
            }
           
        }

        [HttpPut("{Id:Guid}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Guid Id, Customer customer)
        {
            try
            {
                if (Id != customer.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var customerUpdate = await _customerRepository.GetCustomer(Id);
                if (customerUpdate == null)
                {
                    return NotFound($"Customer Id={Id} not Found");
                }

                return await _customerRepository.UpdateCustomer(customer);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }

        }

        [HttpDelete("{Id:Guid}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid Id)
        {
            try
            {
                var customerDelete = await _customerRepository.GetCustomer(Id);
                if (customerDelete == null)
                {
                    return NotFound($"City Id={Id} not Found");
                }

                return await _customerRepository.DeleteCustomer(Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retrieving Data from Database");
            }
        }
    }
}
