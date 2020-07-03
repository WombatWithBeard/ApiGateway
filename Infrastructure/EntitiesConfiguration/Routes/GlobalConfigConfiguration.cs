using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Routes
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