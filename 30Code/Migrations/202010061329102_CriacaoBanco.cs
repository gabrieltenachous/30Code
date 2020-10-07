namespace _30Code.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.usu_usuario",
                c => new
                    {
                        usu_codigo = c.Int(nullable: false, identity: true),
                        usu_nome = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        usu_email = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        usu_senha = c.String(unicode: false),
                        usu_celular = c.String(unicode: false),
                        usu_nascimento = c.DateTime(nullable: false, precision: 0),
                        usu_tipoUsuario = c.Int(nullable: false),
                        usu_sexo = c.Int(nullable: false),
                        usu_confirma_senha = c.String(unicode:false),
                    })
                .PrimaryKey(t => t.usu_codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.usu_usuario");
        }
    }
}
