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
        private readonly VideoClubDbContext _context;

        public CustomerService(VideoClubDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return from c in _context.Customers
                   orderby c.Name
                   select c;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer GetCustomerByName(string name) 
        { 
            return _context.Customers.FirstOrDefault(c => c.Name == name);
        }

        public bool CustomerExists(string name)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Name == name);
            return customer != null;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
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
            var customer = _context.Customers.Find(id);
            if (customer == null) return;
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

       
    }
}
