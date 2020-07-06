using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Routes
{
    public class LoadBalancerOptionConfiguration : IEntityTypeConfiguration<LoadBalancerOption>
    {
        public void Configure(EntityTypeBuilder<LoadBalancerOption> builder)
        {
            builder.ToTable("LoadBalancerOptions");

            builder.HasKey(e => e.LoadBalancerOptionId);

            builder.Property(e => e.LoadBalancerOptionId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}