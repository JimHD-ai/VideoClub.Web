using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VideoClub.Core.Entities;

namespace VideoClub.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCopy> MovieCopies { get; set; }
        public DbSet<MovieRent> MovieRents { get; set; }
    }
}
