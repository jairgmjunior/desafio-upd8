using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Upd8.Core.Domain;
using Upd8.Core.Enums;

namespace Upd8.Data.Configuration
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CodigoIbge).HasMaxLength(7).IsRequired();
            builder.Property(p => p.Estado).HasConversion(new EnumToStringConverter<EEStado>()).HasMaxLength(2).IsRequired();
        }
    }
}
