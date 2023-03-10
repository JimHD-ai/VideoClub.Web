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
    internal class MovieService : IMovieService
    {
        private readonly VideoClubDbContext _context;

        public MovieService(VideoClubDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return from m in _context.Movies
                   orderby m.Title
                   select m;
        }

        public Movie GetMovie(int id)
        {
            return _context.Movies.Find(id);
        }

        public Movie GetMovieByTitle(string title)
        {
            return _context.Movies.FirstOrDefault(m => m.Title == title);
        }

        public bool MovieExists(string title)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Title == title);
            return movie != null;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            var entry = _context.Entry(movie);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null) return;
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
