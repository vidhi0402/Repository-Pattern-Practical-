using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositories.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CrudDBContext _Context;
        private readonly IMapper _mapper;

        public CustomerRepository(CrudDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (_Context.Customer.Any(r => r.CustomerName == customer.CustomerName))
            {
                throw new Exception("Customer Name is Already Exist.");
            }
            else if (_Context.Customer.Any(r => r.Mobile == customer.Mobile))
            {
                throw new Exception("Mobile Number is Already Exist.");
            }
            else if (_Context.Customer.Any(r => r.Email == customer.Email))
            {
                throw new Exception("Email Id is Already Exist.");
            }
            else if (_Context.City.Any(x => x.CityId == customer.CityId))
            {
                var result = await _Context.Customer.AddAsync(customer);
                await _Context.SaveChangesAsync();
                return result.Entity;

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Customer> DeleteCustomer(Guid Id)
        {
            var result = await _Context.Customer.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.Customer.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            var records = await _Context.Customer.Include(a => a.City).ThenInclude(x => x.State).ThenInclude(x => x.Country).ToListAsync();
            return _mapper.Map<List<CustomerModel>>(records);
        }

        public async Task<CustomerModel> GetCustomer(Guid Id)
        {
            var Cities = await _Context.Customer.Include(a => a.City).ThenInclude(x => x.State).ThenInclude(x => x.Country).FirstOrDefaultAsync(a => a.Id == Id);
            return _mapper.Map<CustomerModel>(Cities);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = await _Context.Customer.FirstOrDefaultAsync(a => a.Id == customer.Id);
            if (result != null)
            {
                result.CustomerName = customer.CustomerName;
                result.CityId = customer.CityId;
                result.Email = customer.Email;
                result.Address1 = customer.Address1;
                result.Address2 = customer.Address2;
                result.Address3 = customer.Address3;
                result.Pincode = customer.Pincode;
                result.Mobile = customer.Mobile;
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
