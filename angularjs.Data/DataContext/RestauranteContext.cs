using angularjs.Business.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace angularjs.Data.DataContext
{
    public partial class RestauranteContext : DbContext
    {
        // Your context has been configured to use a 'Restaurante' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'angularjs.Business.Restaurante' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Restaurante' 
        // connection string in the application configuration file.
        public RestauranteContext()
            : base("name=Restaurante")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Prato> Autenticacao { get; set; }
        public virtual DbSet<Restaurante> Documento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prato>()
                .Property(e => e.IdPrato)
                .IsRequired();

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.IdRestaurante)
                .IsRequired();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}