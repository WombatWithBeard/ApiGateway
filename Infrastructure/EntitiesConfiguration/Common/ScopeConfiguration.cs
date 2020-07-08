using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Common
{
    public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
    {
        public void Configure(EntityTypeBuilder<Scope> builder)
        {
            builder.ToTable("Scopes");

            builder.HasKey(e => e.ScopeId);

            builder.Property(e => e.ScopeId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}