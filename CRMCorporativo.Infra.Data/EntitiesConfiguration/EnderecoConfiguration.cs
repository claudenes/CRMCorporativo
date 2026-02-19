using CRMCorporativo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMCorporativo.Infra.Data.EntitiesConfiguration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Logradouro).HasMaxLength(100).IsRequired();

        
    }
}
