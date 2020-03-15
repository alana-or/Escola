using System.Collections.Generic;
using System.Threading.Tasks;
using Escola.Domain.Professores.Entities;

namespace Escola.Domain.Professores.Repositories
{
    public interface IProfessoresRepository
    {
        Task<Professor> Obter(int id);
        Task<IEnumerable<Professor>> Obter();
    }
}