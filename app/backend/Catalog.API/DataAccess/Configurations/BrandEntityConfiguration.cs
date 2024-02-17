namespace Catalog.API.DataAccess.Configurations;

public class BrandEntityConfiguration : IEntityTypeConfiguration<BrandEntity>
{
    public void Configure(EntityTypeBuilder<BrandEntity> builder)
    {
        builder.ToTable("Brand");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).IsRequired();
    }
}
