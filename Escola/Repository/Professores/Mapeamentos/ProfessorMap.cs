using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Escola.Domain.Professores.Entities;

namespace Escola.Repository.Professores.Mapeamentos
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(e => e.Codigo)
            .HasName("PK_Escola_tblprofessores");

            builder.ToTable("tblprofessores", "dbo");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}