using MvcCrudProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MvcCrudProje.Models.Context
{
    public class CrudDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public CrudDbContext()
        {
            Database.Connection.ConnectionString = "server=DESKTOP-41N5UH2\\HALILSQL;database=CrudProje;Trusted_Connection=true";
        }

        public DbSet<Departman> Departman { get; set; }
        public DbSet<Calisan> Calisan { get; set; }
        public DbSet<Login> Login { get; set; } 
    }
}