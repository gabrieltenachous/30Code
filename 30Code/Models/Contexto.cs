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
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Modulo> Modulo { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
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

            var cur = mb.Entity<Curso>();
            cur.ToTable("cur_curso");
            cur.Property(x => x.Id).HasColumnName("cur_id");
            cur.Property(x => x.Nome).HasColumnName("cur_nome");
            cur.Property(x => x.Duracao).HasColumnName("cur_duracao");
            cur.Property(x => x.Url_imagem).HasColumnName("cur_url_imagem");
            cur.Property(x => x.Niveis).HasColumnName("cur_nivel");

            var usuarioHasCurso = mb.Entity<Usuario_has_curso>();
            usuarioHasCurso.ToTable("usu_usuario_has_cur_curso");
            usuarioHasCurso.Property(x => x.Id).HasColumnName("id");
            usuarioHasCurso.Property(x => x.UsuarioId).HasColumnName("usu_id");
            usuarioHasCurso.Property(x => x.CursoId).HasColumnName("cur_id");

            var mod = mb.Entity<Modulo>();
            mod.ToTable("mod_modulo");
            mod.Property(x => x.Id).HasColumnName("mod_id");
            mod.Property(x => x.Titulo).HasColumnName("mod_titulo");
            mod.Property(x => x.CursoId).HasColumnName("cur_id");

        }

        public System.Data.Entity.DbSet<_30Code.Models.Usuario_has_curso> Usuario_has_curso { get; set; }
    }
}