using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Core.Entities
{
    public class MovieCopy
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Boolean Available { get; set; }
        public int Copies { get; set; }
    }
}
