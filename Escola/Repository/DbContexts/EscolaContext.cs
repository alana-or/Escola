using Microsoft.EntityFrameworkCore;
using Escola.Repository.Professores.Mapeamentos;
using Escola.Domain.Professores.Entities;

namespace Escola.Repository.DbContexts
{
    public class EscolaContext : DbContext
    {
        public EscolaContext()
        {
        }

        public EscolaContext(DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professor> Professor { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfessorMap());
        }
    }
}