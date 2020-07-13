using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Routes
{
    public class RouteClaimsRequirementConfiguration : IEntityTypeConfiguration<RouteClaimsRequirement>
    {
        public void Configure(EntityTypeBuilder<RouteClaimsRequirement> builder)
        {
            builder.ToTable("RouteClaimsRequirements");

            builder.HasKey(e => e.RouteClaimsRequirementId);

            builder.Property(e => e.RouteClaimsRequirementId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}