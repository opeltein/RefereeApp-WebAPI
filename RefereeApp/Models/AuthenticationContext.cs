using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RefereeApp.Models;
using System.Reflection;

namespace WebAPI.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<CallendarEvent> CallendarEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityRole>().HasData(new IdentityRole[]
        {
     new IdentityRole("Referee"),
     new IdentityRole("Admin")
         });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("RefereeAppContext");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Stadiums> Stadiums { get; set; }

        public DbSet<Teams> Teams { get; set; }

        public DbSet<Players> Players { get; set; }

        public DbSet<Marks> Marks { get; set; }

        public DbSet<Finances> Finances { get; set; }

        public DbSet<Matches> Matches { get; set; }

        public DbSet<UserMatches> UserMatches { get; set; }

    }
}