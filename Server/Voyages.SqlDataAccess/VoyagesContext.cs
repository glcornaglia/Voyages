using System;
using Voyages.SqlDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Voyages.SqlDataAccess
{
    public class VoyagesContext : DbContext
    {
        private readonly string connectionString;

        public VoyagesContext(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value should not be empty.", nameof(connectionString));

            this.connectionString = connectionString;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(this.connectionString);
        }
    }
}
