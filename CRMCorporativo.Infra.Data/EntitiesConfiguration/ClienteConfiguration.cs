using CRMCorporativo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMCorporativo.Infra.Data.EntitiesConfiguration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Telefone).HasMaxLength(200).IsRequired();

        //builder.Property(p => p.Price).HasPrecision(10, 2);

        builder.HasOne(e => e.Endereco).WithMany(e => e.Clientes)
            .HasForeignKey(e => e.EnderecoId);
    }
}
