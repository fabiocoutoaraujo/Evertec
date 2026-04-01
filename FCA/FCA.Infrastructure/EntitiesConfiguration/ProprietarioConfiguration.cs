using FCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCA.Infrastructure.EntitiesConfiguration;

public class ProprietarioConfiguration : IEntityTypeConfiguration<Proprietario>
{
    public void Configure(EntityTypeBuilder<Proprietario> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(p => p.Nome)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();
        
        builder.Property(p => p.CPF)
               .HasColumnType("varchar")
               .HasMaxLength(14)
               .IsRequired();
        
        builder.Property(p => p.DataNascimento)
               .HasColumnType("date")
               .IsRequired();
    }
}