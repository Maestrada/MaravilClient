using BAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class MaravilContext : DbContext
    {
        public MaravilContext(DbContextOptions<MaravilContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Client>().ToTable("Client");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
}
