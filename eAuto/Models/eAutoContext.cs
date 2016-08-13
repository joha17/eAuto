using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace eAuto.Models
{
    public class eAutoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public eAutoContext() : base("name=eAutoContext")
        {
        }

        //Esto deshabilita los delete en cascada, asi se asegura muchos problemas de borrado de datos sin querer
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Agencia> Agencias { get; set; }

        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<AutoNuevo> AutoNuevos { get; set; }

        public DbSet<EstadoAuto> EstadoAutos { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<AutoUsado> AutoUsados { get; set; }

        public DbSet<Pais> Pais { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
