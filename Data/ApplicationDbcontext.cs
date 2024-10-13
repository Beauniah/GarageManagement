using GarageManagement.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GarageManagement.Data
{
    public class ApplicationDbcontext: IdentityDbContext<AppUser>
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options): base(options) 
        {
            
            
        }
        public DbSet<Ministry> Ministry { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<Incident> Incidents { get; set; }
        
    }
}
