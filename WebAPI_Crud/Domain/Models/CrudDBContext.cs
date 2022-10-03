using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CrudDBContext : DbContext
    {
        public CrudDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Country> Country { get; set; } 
       
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Customer> Customer { get; set; }

    }
}
