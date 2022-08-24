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
            modelBuilder.Entity<Client>().ToTable("Client").HasOne(c=>c.CreatedByUser).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Client>().HasOne(c=>c.ModifiedByUser).WithOne().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasData(new {Id=1, UserName="admin",Password= "24a2a21b503d73db37ec36e1d81168f0" ,CreatedOn=DateTime.Now, ModifiedOn = DateTime.Now });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
