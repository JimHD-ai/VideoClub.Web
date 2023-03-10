using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IMovieCopyService
    {
        IEnumerable<MovieCopy> GetMovieCopies();
        IEnumerable<MovieCopy> GetMovieCopiesByMovieId(int id);
        MovieCopy GetMovieCopy(int id);
        MovieCopy GetFirstAvailableMovieCopy(int movieId, bool available);
        bool MovieCopyExists(int movieId);
        void AddMovieCopy(MovieCopy movieCopy);
    }
}
