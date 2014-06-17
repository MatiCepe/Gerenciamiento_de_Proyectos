using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GP.Dominio.Models;

namespace GP.AccesoaDatos
{
    public class GerenciamientoProyectosContext : DbContext
    {
        public GerenciamientoProyectosContext()
            : base("GerenciamientoProyectosDB")
        {           
        }

        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<Valor> Valor { get; set; }
        public DbSet<Gerente> Gerente { get; set; }
        public DbSet<Factor> Factor { get; set; }
        public DbSet<ProyectoFactor> ProyectoFactor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                // Remocion de la pluralidad de las tablas
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                base.OnModelCreating(modelBuilder);

                // Mapeo de Factor
                modelBuilder.Entity<Factor>().
                HasMany(c => c.ValoresSeleccionados).
                WithMany().
                Map(mc =>
                {
                    mc.MapLeftKey("FactorId");
                    mc.MapRightKey("ValorId");
                    mc.ToTable("FactorValor");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Ha ocurrido un error con el siguiente mensaje: " + e.Message);
            }
            

              
        }
    }
}
