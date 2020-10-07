using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base(nameOrConnectionString: "StringConexao") { }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            var usu = mb.Entity<Usuario>();
            usu.ToTable("usu_usuario");
            usu.Property(x => x.Id).HasColumnName("usu_id");
            usu.Property(x => x.Nome).HasColumnName("usu_nome");
            usu.Property(x => x.Email).HasColumnName("usu_email");
            usu.Property(x => x.Senha).HasColumnName("usu_senha");
            usu.Property(x => x.Sexos).HasColumnName("usu_sexo");
            usu.Property(x => x.Nascimento).HasColumnName("usu_nascimento");
            usu.Property(x => x.TiposUsuarios).HasColumnName("usu_tipoUsuario");
            usu.Property(x => x.Celular).HasColumnName("usu_celular");
            usu.Property(x => x.ConfirmaSenha).HasColumnName("usu_confirma_senha");
        }
    }
}