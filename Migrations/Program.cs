using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Migrations
{
    public class Program
    {
        private static void Main(string[] args) => Executar(args);

        public static void Executar(string[] args)
        {
            var stringDeConexao = "Server=(localdb)\\MSSQLLocalDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

            using (var conexao = new SqlConnection(stringDeConexao))
            {
                var script = $@"IF (NOT EXISTS (SELECT name 
                    FROM master.dbo.sysdatabases 
                    WHERE ('[' + name + ']' = 'Escola'
                    OR name = 'Escola')))
                        BEGIN
                            CREATE DATABASE [Escola]
                        END";

                var comando = new SqlCommand(script, conexao);
                conexao.Open();
                comando.ExecuteNonQuery();
            }

            var provedorDeServicos = CriarServicos(stringDeConexao + "Database=Escola;");

            using (var escopo = provedorDeServicos.CreateScope())
                AtualizarBancoDeDados(escopo.ServiceProvider, args);
        }

        public static IServiceProvider CriarServicos(string connectionString) =>
            new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(construtor => construtor
                    .AddSqlServer2016()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .AddSingleton<IProvedorDeServico>(new ProvedorDeServico() { BancoDeDados = "Escola" })
                .BuildServiceProvider(false);

        public static void AtualizarBancoDeDados(IServiceProvider provedorDeServicos,
            IReadOnlyCollection<string> argumentos = null)
        {
            var executor = provedorDeServicos.GetRequiredService<IMigrationRunner>();

            if (argumentos == null || argumentos.Count == 0)
                executor.MigrateUp();
        }
    }
}
