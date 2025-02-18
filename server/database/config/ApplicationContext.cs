using Microsoft.EntityFrameworkCore;
using test_Faza.database.constants;
using test_Faza.database.entities;

namespace test_Faza.database.config
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Interface> Interfaces { get; set; } = null!;
        public DbSet<Device> Devices { get; set; } = null!;
        public DbSet<Register> Registers { get; set; } = null!;
        public DbSet<RegisterValue> RegisterValues { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=test_faza.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // генерация интерфейсов
            for (int i = 0; i < DefaultData.defaultInterfaces.Length; i++)
            {
                modelBuilder.Entity<Interface>().HasData(DefaultData.defaultInterfaces[i]);
            }

            // генерация девайсов
            for (int i = 0; i < DefaultData.defaultDevices.Length; i++)
            {
                modelBuilder.Entity<Device>().HasData(DefaultData.defaultDevices[i]);
            }

            // генерация регистров
            for (int i = 0; i < DefaultData.defaultRegisters.Length; i++)
            {
                modelBuilder.Entity<Register>().HasData(DefaultData.defaultRegisters[i]);
            }
        }

    }

}
