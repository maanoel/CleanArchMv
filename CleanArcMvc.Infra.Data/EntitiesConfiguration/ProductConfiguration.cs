using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasPrecision(10, 2);

            builder
                .HasOne(e => e.Category)
                .WithMany(e=> e.Products)
                .HasForeignKey(e => e.CategoryId);

            var first = new Product(1, "Caderno", "100 folhas", 7, "cardeno1.jpg", 1);
            first.CategoryId = 1;

            var second = new Product(2, "Estojo", "cinza", 12, "estojo1.jpg", 2);
            second.CategoryId = 2;

            var third = new Product(3, "Teste", "cinza", 12, "estojo1.jpg", 2);
            third.CategoryId = 2;

            builder.HasData(first, second, third);
        }
    }
}
