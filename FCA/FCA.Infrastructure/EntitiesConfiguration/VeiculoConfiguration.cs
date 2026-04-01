using FCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCA.Infrastructure.EntitiesConfiguration;

public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(p => p.Placa)
               .HasColumnType("varchar")
               .HasMaxLength(8)
               .IsRequired();
        
        builder.Property(p => p.Modelo)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();
        
        builder.Property(p => p.Ano)
               .IsRequired();

        builder.HasOne(e => e.Proprietario)
               .WithMany(e => e.Veiculos)
               .HasForeignKey(e => e.ProprietarioId);
    }
}