using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Veritabanı'ndaki tablolar ile entity'lerimizi ilişkilendirdik.

    public class GraduationProjectContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InstallmentOption> InstallmentOptions { get; set; }
        public DbSet<InsuredPerson> InsuredPersons { get; set; }
        public DbSet<InsuredPersonRelationship> InsuredPersonRelationships { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-TAKPAA66;Database=GraduationProject;Trusted_Connection=true");
        }
    }
}
