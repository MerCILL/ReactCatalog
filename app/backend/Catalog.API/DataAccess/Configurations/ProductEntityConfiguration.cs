namespace Catalog.API.DataAccess.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Price).IsRequired();

        builder.HasOne(t => t.Type).WithMany();
        builder.HasOne(b => b.Brand).WithMany();
    }
}
