using AutoMapper;
using Escola.Domain.Professores.Entities;
using Escola.Models;

namespace Escola
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Professor, ProfessorModel>();
        }
    }
}
