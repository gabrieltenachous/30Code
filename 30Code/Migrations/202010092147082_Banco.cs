namespace _30Code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cur_curso",
                c => new
                {
                    cur_id = c.Int(nullable: false, identity: true),
                    cur_nome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    cur_duracao = c.Double(nullable: false),
                    cur_url_imagem = c.String(unicode: false),
                    cur_nivel = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.cur_id);

            CreateTable(
                "dbo.mod_modulo",
                c => new
                {
                    mod_id = c.Int(nullable: false, identity: true),
                    mod_titulo = c.String(nullable: false, unicode: false),
                    cur_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.mod_id)
                .ForeignKey("dbo.cur_curso", t => t.cur_id, cascadeDelete: true);

            CreateTable(
                "dbo.usu_usuario",
                c => new
                {
                    usu_id = c.Int(nullable: false, identity: true),
                    usu_nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                    usu_email = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    usu_senha = c.String(nullable: false, unicode: false),
                    usu_celular = c.String(unicode: false),
                    usu_nascimento = c.DateTime(precision: 0),
                    usu_tipoUsuario = c.Int(nullable: false),
                    usu_sexo = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.usu_id);

            CreateTable(
                "dbo.usu_usuario_has_cur_curso",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    usu_id = c.Int(nullable: false),
                    cur_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cur_curso", t => t.cur_id, cascadeDelete: true)
                .ForeignKey("dbo.usu_usuario", t => t.usu_id, cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.usu_usuario_has_cur_curso", "usu_id", "dbo.usu_usuario");
            DropForeignKey("dbo.usu_usuario_has_cur_curso", "cur_id", "dbo.cur_curso");
            DropForeignKey("dbo.mod_modulo", "cur_id", "dbo.cur_curso");
            DropIndex("dbo.usu_usuario_has_cur_curso", new[] { "cur_id" });
            DropIndex("dbo.usu_usuario_has_cur_curso", new[] { "usu_id" });
            DropIndex("dbo.mod_modulo", new[] { "cur_id" });
            DropTable("dbo.usu_usuario_has_cur_curso");
            DropTable("dbo.usu_usuario");
            DropTable("dbo.mod_modulo");
            DropTable("dbo.cur_curso");
        }
    }
}
