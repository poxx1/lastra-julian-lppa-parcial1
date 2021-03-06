using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LastraJulian_LPPA_Parcial1.Models;

namespace LastraJulian_LPPA_Parcial1.Services
{
    public class MyDbContext : DbContext
    {
        public DbSet<Afiliados> Afiliados { get; set; }

        public MyDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}