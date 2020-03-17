using Escola.Domain.Professores.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Escola.Domain.Professores.Entities;
using Escola.Models;

namespace Escola.Services.Professores
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorModel>> BuscarProfessores();
        Task<ProfessorModel> BuscarProfessor(int id);
    }

    public class ProfessorService : IProfessorService
    {
        private readonly IProfessoresRepository professoresRepository;
        private readonly IMapper mapper;

        public ProfessorService(IProfessoresRepository professoresRepository, IMapper mapper)
        {
            this.professoresRepository = professoresRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProfessorModel>> BuscarProfessores()
        {
            var professores = (await professoresRepository.Obter()).ToList();

            return mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorModel>>(professores);
        }

        public async Task<ProfessorModel> BuscarProfessor(int id)
        {
            var professores = await professoresRepository.Obter(id);

            return mapper.Map<Professor, ProfessorModel>(professores);
        }
    }
}
