using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return from c in _context.Users
                   orderby c.FirstName
                   select c;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Users.Find(id);
        }

        public Customer GetCustomerByName(string name) 
        { 
            return _context.Users.FirstOrDefault(c => c.FirstName == name);
        }

        public bool CustomerExists(string name)
        {
            var customer = _context.Users.FirstOrDefault(c => c.FirstName == name);
            return customer != null;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Users.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var entry = _context.Entry(customer);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Users.Find(id);
            if (customer == null) return;
            _context.Users.Remove(customer);
            _context.SaveChanges();
        }

       
    }
}
