using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Escola.Repository.DbContexts;
using System.Threading.Tasks;
using Escola.Domain.Professores.Repositories;
using Escola.Domain.Professores.Entities;

namespace Escola.Repository.Professores
{
    public class ProfessoresRepository : IProfessoresRepository
    {
        private readonly EscolaContext EscolaContext;

        public ProfessoresRepository(EscolaContext EscolaContext)
            => this.EscolaContext = EscolaContext;

        public async Task<Professor> Obter(int id)
            => await EscolaContext.Professor.FindAsync(id);

        public async Task<IEnumerable<Professor>> Obter()
            => await EscolaContext.Professor.ToListAsync();
    }
}