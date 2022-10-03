using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Repositories.IRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerModel>> GetAll();
        Task<CustomerModel> GetCustomer(Guid Id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> DeleteCustomer(Guid Id);
    }
}
