using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Upd8.Core.Domain;

namespace Upd8.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CPF).HasMaxLength(11).IsRequired();
            builder.Property(p => p.DataNascimento).IsRequired();
            builder.Property(p => p.Sexo).IsRequired();
        }
    }
}
