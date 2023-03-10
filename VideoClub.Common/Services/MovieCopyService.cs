using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class MovieCopyService : IMovieCopyService
    {
        private readonly ApplicationDbContext _context;

        public MovieCopyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieCopy> GetMovieCopies()
        {
            return from m in _context.MovieCopies
                   orderby m.Id
                   select m;
        }

        public IEnumerable<MovieCopy> GetMovieCopiesByMovieId(int id)
        {
            return from m in _context.MovieCopies
                   where m.Movie.Id == id
                   orderby m.Id
                   select m;
        }

        public MovieCopy GetMovieCopy(int id)
        {
            return _context.MovieCopies.Find(id);
        }

       public MovieCopy GetFirstAvailableMovieCopy(int movieId, bool available)
        {
            return _context.MovieCopies.FirstOrDefault(m => m.Movie.Id == movieId && m.Available == available);
        }

        public bool MovieCopyExists(int movieId)
        {
            var movieCopy = _context.MovieCopies.FirstOrDefault(m => m.Movie.Id == movieId);
            return movieCopy != null;
        }

        public void AddMovieCopy(MovieCopy movieCopy)
        {
            _context.MovieCopies.Add(movieCopy);
            _context.SaveChanges();
        }
    }
}
