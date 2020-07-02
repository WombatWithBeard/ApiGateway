using Domain.Entities.Ocelot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Ocelot
{
    public class AuthenticationOptionConfiguration: IEntityTypeConfiguration<AuthenticationOption>
    {
        public void Configure(EntityTypeBuilder<AuthenticationOption> builder)
        {
            builder.ToTable("AuthenticationOptions");

            builder.HasKey(e => e.AuthenticationOptionId);

            builder.Property(e => e.AuthenticationOptionId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}