using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

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

        public System.Data.Entity.DbSet<eAuto.Models.Agencia> Agencias { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.Modelo> Modeloes { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.Marca> Marcas { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.AutoNuevo> AutoNuevoes { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.EstadoAuto> EstadoAutoes { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.AutoUsado> AutoUsadoes { get; set; }

        public System.Data.Entity.DbSet<eAuto.Models.Pais> Pais { get; set; }
    }
}
