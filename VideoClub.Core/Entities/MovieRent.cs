using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Core.Entities
{
    public class MovieRent
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public MovieCopy MovieCopy { get; set; }
        public int MovieCopyId { get; set; }
        public Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Boolean Returned { get; set; }
    }
}
