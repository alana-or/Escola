using AutoBogus;
using Escola.Domain.Professores.Entities;
using System.Threading.Tasks;
using Escola.Repository.DbContexts;

namespace SimpressUX.API.Builders.Professors
{
    public class ProfessorBuilder : AutoFaker<Professor>
    {
        private int codigo;
        private string nome;

        public ProfessorBuilder() : base("pt_BR")
        {
            StrictMode(false);
            RuleFor(x => x.Codigo, f => 0);
            RuleFor(x => x.Nome, f => null);
        }

        public ProfessorBuilder ComCodigo(int codigoProfessor)
        {
            this.codigo = codigoProfessor;
            RuleFor(x => x.Codigo, codigoProfessor);
            return this;
        }

        public ProfessorBuilder ComNome(string nome)
        {
            this.nome = nome;
            RuleFor(x => x.Nome, nome);
            return this;
        }

        public Professor Instanciar()
            => new Professor
            {
                Codigo = codigo,
                Nome = nome ?? "Nome Teste"
            };

        public async Task<Professor> CriarNoBancoDeDados(EscolaContext escolaContext)
        {
            var Professor = Instanciar();
            escolaContext.Professor.Add(Professor);
            await escolaContext.SaveChangesAsync();
            return Professor;
        }
    }
}
