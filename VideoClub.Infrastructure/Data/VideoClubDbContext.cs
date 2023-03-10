using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Web.Models;

namespace VideoClub.Infrastructure.Data
{
    public class VideoClubDbContext : IdentityDbContext<ApplicationUser>
    {
        public VideoClubDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static VideoClubDbContext Create()
        {
            return new VideoClubDbContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCopy> MovieCopies { get; set; }
        public DbSet<MovieRent> MovieRents { get; set; }
    }
}
