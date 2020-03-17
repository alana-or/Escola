using System.Collections.Generic;
using Escola.Repository.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using Escola.Domain.Professores.Entities;
using SimpressUX.API.Builders.Professors;

namespace Escola.Seed
{
    public interface ISeedBancoDeDados
    {
        Task AplicarSeed();
    }

    public class EscolaSeed : ISeedBancoDeDados
    {
        private readonly EscolaContext context;
        private readonly IConfiguration config;

        public EscolaSeed(EscolaContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public async Task AplicarSeed()
        {
            await CriarDadosProfessor();
        }

        private async Task CriarDadosProfessor()
        {
            var professores = new List<Professor>();

            for (var codigoProfessor = 1; codigoProfessor <= 10; codigoProfessor++)
            {
                professores.Add(new ProfessorBuilder()
                    .ComCodigo(codigoProfessor)
                    .ComNome("Professor " + codigoProfessor)
                    .Instanciar());
            }

            await context.Professor.AddRangeAsync(professores);
            await context.SaveChangesAsync();
        }
    }
}
