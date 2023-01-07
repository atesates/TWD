using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.Entities.Concrete;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.DAL.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database = Northwind; trusted_Connection=true");
            options.UseSqlServer(@"Server=D10091\MSSQLSERVER01;Database = Northwind; trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
