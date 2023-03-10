using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Infrastructure.Data;
using VideoClub.Web.Models;

namespace Seeder
{
    internal class Program
    {
        public static void CreateDefaultRolesAndUsers(VideoClubDbContext dbContext)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
            var role = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {
                role.Name = "Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                const string userName = "admin@google.gr";

                user.UserName = userName;
                user.Email = userName;

                var check = userManager.Create(user, "Admin1");

                if(check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    var exception = new Exception("Can't create default user");

                    var enumerator = check.Errors.GetEnumerator();
                    foreach (var error in check.Errors) 
                    {
                        exception.Data.Add(enumerator.Current, error);
                    }
                    throw exception;
                }
            }
        }

        static void Main(string[] args)
        {
            var context = new VideoClubDbContext();
            CreateDefaultRolesAndUsers(context);
        }
    }
}
