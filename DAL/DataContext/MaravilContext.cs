using BAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
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

            modelBuilder.Entity<State>().ToTable("State").HasMany(x => x.Towns).WithOne();

            modelBuilder.Entity<Town>().ToTable("Town").HasMany(x => x.Clients).WithOne();
            modelBuilder.Entity<Town>().HasOne(x => x.State).WithMany(x => x.Towns).HasForeignKey(x => x.StateId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().ToTable("User").HasMany(x => x.ClientsCreators).WithOne();
            modelBuilder.Entity<User>().HasMany(x => x.ClientsModificators).WithOne();

            modelBuilder.Entity<Order>().ToTable("Order").HasOne(x=>x.Client).WithOne();

            modelBuilder.Entity<Client>().ToTable("Client").HasOne(c => c.CreatedByUser).WithMany(x => x.ClientsCreators).HasForeignKey(x => x.CreatedByUserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>().HasOne(c => c.ModifiedByUser).WithMany(x => x.ClientsModificators).HasForeignKey(x => x.ModifiedByUserId).OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<Client>().HasOne(c => c.Town).WithMany(x => x.Clients).HasForeignKey(x => x.TownId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Client>().HasMany(c => c.Orders).WithOne(x => x.Client).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(new { Id = 1, UserName = "admin", Password = "bca6062db9ffe0bdb13f01b5dc48f6e0e7d0f8c8a21af0324c9971d3fbd51e08", CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now, IsSystemAdmin = true, ActiveStatus = true });

            modelBuilder.Entity<State>().HasData(new { Id = 1, Name = "Boaco", });
            modelBuilder.Entity<State>().HasData(new { Id = 2, Name = "Carazo", });
            modelBuilder.Entity<State>().HasData(new { Id = 3, Name = "Chinandega", });
            modelBuilder.Entity<State>().HasData(new { Id = 4, Name = "Chontales", });
            modelBuilder.Entity<State>().HasData(new { Id = 5, Name = "Costa Caribe Norte", });
            modelBuilder.Entity<State>().HasData(new { Id = 6, Name = "Costa Caribe Sur", });
            modelBuilder.Entity<State>().HasData(new { Id = 7, Name = "Estelí", });
            modelBuilder.Entity<State>().HasData(new { Id = 8, Name = "Granada", });
            modelBuilder.Entity<State>().HasData(new { Id = 9, Name = "Jinotega", });
            modelBuilder.Entity<State>().HasData(new { Id = 10, Name = "León", });
            modelBuilder.Entity<State>().HasData(new { Id = 11, Name = "Madriz", });
            modelBuilder.Entity<State>().HasData(new { Id = 12, Name = "Managua", });
            modelBuilder.Entity<State>().HasData(new { Id = 13, Name = "Masaya", });
            modelBuilder.Entity<State>().HasData(new { Id = 14, Name = "Matagalpa", });
            modelBuilder.Entity<State>().HasData(new { Id = 15, Name = "Nueva Segovia", });
            modelBuilder.Entity<State>().HasData(new { Id = 16, Name = "Río San Juan", });
            modelBuilder.Entity<State>().HasData(new { Id = 17, Name = "Rivas", });

            modelBuilder.Entity<Town>().HasData(new { Id = 1, Name = "Boaco", StateId = 1 });
            modelBuilder.Entity<Town>().HasData(new { Id = 2, Name = "Camoapa", StateId = 1 });
            modelBuilder.Entity<Town>().HasData(new { Id = 3, Name = "San José de los Remates", StateId = 1 });
            modelBuilder.Entity<Town>().HasData(new { Id = 4, Name = "San Lorenzo", StateId = 1 });
            modelBuilder.Entity<Town>().HasData(new { Id = 5, Name = "Santa Lucía", StateId = 1 });
            modelBuilder.Entity<Town>().HasData(new { Id = 6, Name = "Teustepe", StateId = 1 });
            modelBuilder.Entity<Town>().HasData(new { Id = 7, Name = "Diriamba", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 8, Name = "Dolores", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 9, Name = "El Rosario", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 10, Name = "Jinotepe", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 11, Name = "La Conquista", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 12, Name = "La Paz de Oriente", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 13, Name = "San Marcos", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 14, Name = "Santa Teresa", StateId = 2 });
            modelBuilder.Entity<Town>().HasData(new { Id = 15, Name = "Chichigalpa", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 16, Name = "Chinandega", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 17, Name = "Cinco Pinos", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 18, Name = "Corinto", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 19, Name = "El Realejo", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 20, Name = "El Viejo", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 21, Name = "Posoltega", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 22, Name = "Puerto Morazán", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 23, Name = "San Francisco del Norte", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 24, Name = "San Pedro del Norte", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 25, Name = "Santo Tomás del Norte", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 26, Name = "Somotillo", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 27, Name = "Villanueva", StateId = 3 });
            modelBuilder.Entity<Town>().HasData(new { Id = 28, Name = "Acoyapa", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 29, Name = "Comalapa", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 30, Name = "Cuapa", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 31, Name = "El Coral", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 32, Name = "Juigalpa", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 33, Name = "La Libertad", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 34, Name = "San Pedro de Lóvago", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 35, Name = "Santo Domingo", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 36, Name = "Santo Tomás", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 37, Name = "Villa Sandino", StateId = 4 });
            modelBuilder.Entity<Town>().HasData(new { Id = 38, Name = "Bonanza", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 39, Name = "Mulukukú", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 40, Name = "Prinzapolka", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 41, Name = "Puerto Cabezas", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 42, Name = "Rosita", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 43, Name = "Siuna", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 44, Name = "Waslala", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 45, Name = "Waspán", StateId = 5 });
            modelBuilder.Entity<Town>().HasData(new { Id = 46, Name = "Bluefields", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 47, Name = "Corn Island", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 48, Name = "Desembocadura de Río Grande", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 49, Name = "El Ayote", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 50, Name = "El Rama", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 51, Name = "El Tortuguero", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 52, Name = "Kukra Hill", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 53, Name = "La Cruz de Río Grande", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 54, Name = "Laguna de Perlas", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 55, Name = "Muelle de los Bueyes", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 56, Name = "Nueva Guinea", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 57, Name = "Paiwas", StateId = 6 });
            modelBuilder.Entity<Town>().HasData(new { Id = 58, Name = "Condega", StateId = 7 });
            modelBuilder.Entity<Town>().HasData(new { Id = 59, Name = "Estelí", StateId = 7 });
            modelBuilder.Entity<Town>().HasData(new { Id = 60, Name = "La Trinidad", StateId = 7 });
            modelBuilder.Entity<Town>().HasData(new { Id = 61, Name = "Pueblo Nuevo", StateId = 7 });
            modelBuilder.Entity<Town>().HasData(new { Id = 62, Name = "San Juan de Limay", StateId = 7 });
            modelBuilder.Entity<Town>().HasData(new { Id = 63, Name = "San Nicolás", StateId = 7 });
            modelBuilder.Entity<Town>().HasData(new { Id = 64, Name = "Diriá", StateId = 8 });
            modelBuilder.Entity<Town>().HasData(new { Id = 65, Name = "Diriomo", StateId = 8 });
            modelBuilder.Entity<Town>().HasData(new { Id = 66, Name = "Granada", StateId = 8 });
            modelBuilder.Entity<Town>().HasData(new { Id = 67, Name = "Nandaime", StateId = 8 });
            modelBuilder.Entity<Town>().HasData(new { Id = 68, Name = "El Cuá", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 69, Name = "Jinotega", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 70, Name = "La Concordia", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 71, Name = "San José de Bocay", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 72, Name = "San Rafael del Norte", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 73, Name = "San Sebastián de Yalí", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 74, Name = "Santa María de Pantasma", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 75, Name = "Wiwilí de Jinotega", StateId = 9 });
            modelBuilder.Entity<Town>().HasData(new { Id = 76, Name = "Achuapa", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 77, Name = "El Jicaral", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 78, Name = "El Sauce", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 79, Name = "La Paz Centro", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 80, Name = "Larreynaga", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 81, Name = "León", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 82, Name = "Nagarote", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 83, Name = "Quezalguaque", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 84, Name = "Santa Rosa del Peñón", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 85, Name = "Telica", StateId = 10 });
            modelBuilder.Entity<Town>().HasData(new { Id = 86, Name = "Las Sabanas", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 87, Name = "Palacagüina", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 88, Name = "San José de Cusmapa", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 89, Name = "San Juan de Río Coco", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 90, Name = "San Lucas", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 91, Name = "Somoto", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 92, Name = "Telpaneca", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 93, Name = "Totogalpa", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 94, Name = "Yalagüina", StateId = 11 });
            modelBuilder.Entity<Town>().HasData(new { Id = 95, Name = "Ciudad Sandino", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 96, Name = "El Crucero", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 97, Name = "Managua", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 98, Name = "Mateare", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 99, Name = "San Francisco Libre", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 100, Name = "San Rafael del Sur", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 101, Name = "Ticuantepe", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 102, Name = "Tipitapa", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 103, Name = "Villa El Carmen", StateId = 12 });
            modelBuilder.Entity<Town>().HasData(new { Id = 104, Name = "Catarina", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 105, Name = "La Concepción", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 106, Name = "Masatepe", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 107, Name = "Masaya", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 108, Name = "Nandasmo", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 109, Name = "Nindirí", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 110, Name = "Niquinohomo", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 111, Name = "San Juan de Oriente", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 112, Name = "Tisma", StateId = 13 });
            modelBuilder.Entity<Town>().HasData(new { Id = 113, Name = "Ciudad Darío", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 114, Name = "El Tuma - La Dalia", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 115, Name = "Esquipulas", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 116, Name = "Matagalpa", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 117, Name = "Matiguás", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 118, Name = "Muy Muy", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 119, Name = "Rancho Grande", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 120, Name = "Río Blanco", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 121, Name = "San Dionisio", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 122, Name = "San Isidro", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 123, Name = "San Ramón", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 124, Name = "Sébaco", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 125, Name = "Terrabona", StateId = 14 });
            modelBuilder.Entity<Town>().HasData(new { Id = 126, Name = "Ciudad Antigua", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 127, Name = "Dipilto", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 128, Name = "El Jícaro", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 129, Name = "Jalapa", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 130, Name = "Macuelizo", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 131, Name = "Mozonte", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 132, Name = "Murra", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 133, Name = "Ocotal", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 134, Name = "Quilalí", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 135, Name = "San Fernando", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 136, Name = "Santa María", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 137, Name = "Wiwilí", StateId = 15 });
            modelBuilder.Entity<Town>().HasData(new { Id = 138, Name = "El Almendro", StateId = 16 });
            modelBuilder.Entity<Town>().HasData(new { Id = 139, Name = "El Castillo", StateId = 16 });
            modelBuilder.Entity<Town>().HasData(new { Id = 140, Name = "Morrito", StateId = 16 });
            modelBuilder.Entity<Town>().HasData(new { Id = 141, Name = "San Carlos", StateId = 16 });
            modelBuilder.Entity<Town>().HasData(new { Id = 142, Name = "San Juan del Norte", StateId = 16 });
            modelBuilder.Entity<Town>().HasData(new { Id = 143, Name = "San Miguelito", StateId = 16 });
            modelBuilder.Entity<Town>().HasData(new { Id = 144, Name = "Altagracia", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 145, Name = "Belén", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 146, Name = "Buenos Aires", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 147, Name = "Cárdenas", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 148, Name = "Moyogalpa", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 149, Name = "Potosí", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 150, Name = "Rivas", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 151, Name = "San Jorge", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 152, Name = "San Juan del Sur", StateId = 17 });
            modelBuilder.Entity<Town>().HasData(new { Id = 153, Name = "Tola", StateId = 17 });

        }

        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}
