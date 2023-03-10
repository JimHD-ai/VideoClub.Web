using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class MovieRentServices : IMovieRentService
    {
        private readonly VideoClubDbContext _context;

        public MovieRentServices(VideoClubDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<MovieRent> GetMovieRents()
        {
            return from m in _context.MovieRents
                   orderby m.Id
                   select m;
        }

        public MovieRent GetMovieRent(int id)
        {
            return _context.MovieRents.Find(id);
        }

        public MovieRent GetMovieRentByCustomer(int customerId)
        {
            return _context.MovieRents.FirstOrDefault(m => m.Customer.Id == customerId);
        }

        public bool MovieRentExists(int customerId)
        {
            var movieRent = _context.MovieRents.FirstOrDefault(m => m.Customer.Id == customerId);
            return movieRent != null;
        }

        public void AddMovieRent(MovieRent movieRent)
        {
            _context.MovieRents.Add(movieRent);
            _context.SaveChanges();
        }

        public void UpdateMovieRent(MovieRent movieRent)
        {
            var entry = _context.Entry(movieRent);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
