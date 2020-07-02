using Domain.Entities.Ocelot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Ocelot
{
    public class DownstreamHostAndPortConfiguration : IEntityTypeConfiguration<DownstreamHostAndPort>
    {
        public void Configure(EntityTypeBuilder<DownstreamHostAndPort> builder)
        {
            builder.ToTable("DownstreamHostAndPorts");

            builder.HasKey(e => e.DownstreamHostAndPortId);

            builder.Property(e => e.DownstreamHostAndPortId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}