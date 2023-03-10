using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Enumerations;

namespace VideoClub.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Boolean Available { get; set; }
        public MovieGenre Genre { get; set; }
    }
}
