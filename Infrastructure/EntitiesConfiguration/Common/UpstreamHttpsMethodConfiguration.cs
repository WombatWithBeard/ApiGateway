using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Common
{
    public class UpstreamHttpsMethodConfiguration : IEntityTypeConfiguration<UpstreamHttpsMethod>
    {
        public void Configure(EntityTypeBuilder<UpstreamHttpsMethod> builder)
        {
            builder.ToTable("UpstreamHttpsMethods");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}