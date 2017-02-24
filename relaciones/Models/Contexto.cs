using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace relaciones.Models
{
    public class Contexto:DbContext
    {
        public Contexto()
            :base("DefaultConnection")
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Viaje> Viaje { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // llaves primarias
            modelBuilder.Entity<Clientes>().HasKey(x => x.IdCliente);
            modelBuilder.Entity<Departamento>().HasKey(x => x.IdDepartamento);
            modelBuilder.Entity<Viaje>().HasKey(x => x.IdViaje);



            modelBuilder.Entity<Clientes>().Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Departamento>().Property(x => x.NombreDepartamento).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Viaje>().Property(x => x.Vendio).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Viaje>().Property(x => x.Cobro).IsRequired();
            

        }
    }
}