using DevIO.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        void IEntityTypeConfiguration<Address>.Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.PublicPlace)
                .IsRequired()
                .HasColumnName("ADR_PUBLIC_PLACE")
                .HasColumnType("varchar(200)");

            builder
                .Property(p => p.Number)
                .IsRequired()
                .HasColumnName("ADR_NUMBER")
                .HasColumnType("varchar(50)");

            builder
                .Property(p => p.Complement)
                .IsRequired()
                .HasColumnName("ADR_COMPLEMENT")
                .HasColumnType("varchar(250)");

            builder
                .Property(p => p.Cep)
                .IsRequired()
                .HasColumnName("ADR_CEP")
                .HasColumnType("varchar(8)");

            builder
                .Property(p => p.District)
                .IsRequired()
                .HasColumnName("ADR_DISTRICT")
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.City)
                .IsRequired()
                .HasColumnName("ADR_CITY")
                .HasColumnType("varchar(100)");

            builder
               .Property(p => p.State)
               .IsRequired()
               .HasColumnName("ADR_STATE")
               .HasColumnType("varchar(50)");

            builder.ToTable("ADRESSES");

        }
    }
}
