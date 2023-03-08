
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unipluss.Sign.ExternalContract.Entities;
using DutchTreat.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace DutchTreat.Data
{
    public class DutchContext : DbContext
    {
        public readonly IConfiguration _config;

        public DutchContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DutchContextDb"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
        }
    }
}
