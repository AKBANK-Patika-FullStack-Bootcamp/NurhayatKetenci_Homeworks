using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class UserContext:DbContext
    {

        public UserContext()
        {
        }
        protected readonly IConfiguration Configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Shopping;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Adress>().ToTable("Adress");
            modelBuilder.Entity<APIAuthority>().ToTable("APIAuthority");
        }
        public DbSet<User> User { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<APIAuthority> APIAuthority { get; set; }
    }
}
