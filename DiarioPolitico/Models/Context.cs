using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DiarioPolitico.Models
{
    public class Context : DbContext
    {
        public DbSet<Usuario> users { get; set; }
        public DbSet<Proyecto> projects { get; set; }
        public DbSet<Comentario> commentaries { get; set; }
        public DbSet<Noticia> noticias { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public Context() : base("cnStr") { }
    }


}