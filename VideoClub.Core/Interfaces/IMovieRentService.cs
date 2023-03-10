using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IMovieRentService
    {
        IEnumerable<MovieRent> GetMovieRents();
        MovieRent GetMovieRent(int id);
        MovieRent GetMovieRentByCustomer(int customerId);
        bool MovieRentExists(int customerId);
        void AddMovieRent(MovieRent movieRent);
        void UpdateMovieRent(MovieRent movieRent);
    }
}
