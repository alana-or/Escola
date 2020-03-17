using FluentMigrator;

namespace Migrations.Escola
{
    [Migration(202003150000)]
    public class InitialMigration : Migration
    {
        private const string nomeTabela = "tblprofessores";
        private const string chavePrimaria = "PK_Escola_tblprofessores";
        
        public override void Up()
        {
            Create
                .Table(nomeTabela)
                .WithColumn("codigo").AsInt32()
                .WithColumn("nome").AsString();

            Create.PrimaryKey(chavePrimaria).OnTable(nomeTabela).Column("codigo");
        }

        public override void Down()
        {
            Delete.PrimaryKey(chavePrimaria).FromTable(nomeTabela);
            Delete.Table(nomeTabela);
        }
    }
}
