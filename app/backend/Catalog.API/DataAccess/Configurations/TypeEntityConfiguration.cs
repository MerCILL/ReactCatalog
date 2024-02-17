namespace Catalog.API.DataAccess.Configurations;

public class TypeEntityConfiguration : IEntityTypeConfiguration<TypeEntity>
{
    public void Configure(EntityTypeBuilder<TypeEntity> builder)
    {
        builder.ToTable("Type");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title).IsRequired();
    }
}
