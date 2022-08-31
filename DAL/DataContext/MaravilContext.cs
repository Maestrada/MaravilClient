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
            modelBuilder.Entity<User>().ToTable("User").HasMany(x => x.ClientsCreators).WithOne();
            modelBuilder.Entity<User>().HasMany(x => x.ClientsModificators).WithOne();
            modelBuilder.Entity<Client>().ToTable("Client").HasOne(c => c.CreatedByUser).WithMany(x=>x.ClientsCreators).HasForeignKey(x=>x.CreatedByUserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>().HasOne(c=>c.ModifiedByUser).WithMany(x=>x.ClientsModificators).HasForeignKey(x=>x.ModifiedByUserId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<User>().HasData(new {Id=1, UserName="admin",Password= "bca6062db9ffe0bdb13f01b5dc48f6e0e7d0f8c8a21af0324c9971d3fbd51e08", CreatedOn=DateTime.Now, ModifiedOn = DateTime.Now });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
