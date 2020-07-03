using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Routes
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