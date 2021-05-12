using DevIO.Bussiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnName("PRD_NAME")
                .HasColumnType("varchar(200)");

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasColumnName("PRD_DESCRIPTION")
                .HasColumnType("varchar(1000)");

            builder
                .Property(p => p.Image)
                .IsRequired()
                .HasColumnName("PRD_IMAGE")
                .HasColumnType("varchar(100)");

            builder
                .Property(p => p.Value)
                .IsRequired()
                .HasColumnName("PRD_VALUE")
                .HasColumnType("decimal");

            builder
                .Property(p => p.CreateDate)
                .IsRequired()
                .HasColumnName("PRD_CREATE_DATE")
                .HasColumnType("datetime");

            builder
                .Property(p => p.Active)
                .IsRequired()
                .HasColumnName("PRD_ACTIVE")
                .HasColumnType("bit");

            builder.ToTable("PRODUCTS");
        }
    }
}
