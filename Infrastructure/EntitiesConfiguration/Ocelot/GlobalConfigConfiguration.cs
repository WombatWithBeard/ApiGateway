using Domain.Entities.Ocelot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Ocelot
{
    public class GlobalConfigConfiguration : IEntityTypeConfiguration<GlobalConfiguration>
    {
        public void Configure(EntityTypeBuilder<GlobalConfiguration> builder)
        {
            builder.ToTable("GlobalConfigurations");

            builder.HasKey(e => e.GlobalConfigurationId);

            builder.Property(e => e.GlobalConfigurationId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}