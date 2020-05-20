using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Tax.Core.Entities;
using Tax.Infrastructure;

namespace Tax.Persistence.EF
{
    public class TaxContext : DbContext
    {
        private readonly string sqlConnectionString;

        public TaxContext()
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            this.sqlConnectionString = new Settings(AppDomain.CurrentDomain.BaseDirectory, "development")
                .SqlServer.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(sqlConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CalculatedTaxEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

        public DbSet<CalculatedTaxEntity> CalculatedTaxEntities { get; set; }
    }
}
