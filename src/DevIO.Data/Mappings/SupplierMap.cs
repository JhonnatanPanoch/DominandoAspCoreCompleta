using DevIO.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnName("SUP_NAME")
                .HasColumnType("varchar(200)");

            builder
                .Property(p => p.Document)
                .IsRequired()
                .HasColumnName("SUP_DOCUMENT")
                .HasColumnType("varchar(14)");

            builder
                .Property(p => p.Active)
                .IsRequired()
                .HasColumnName("SUP_ACTIVE")
                .HasColumnType("bit");

            // 1 : 1 => fornecedor > endereco
            builder
                .HasOne(f => f.Address)
                .WithOne(x => x.Supplier);

            // 1 : n => fornecedor > produtos
            builder
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            builder.ToTable("SUPPLIERS");
        }
    }
}
