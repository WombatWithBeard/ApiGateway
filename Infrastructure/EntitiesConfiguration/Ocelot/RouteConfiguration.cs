﻿using Domain.Entities.Ocelot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration.Ocelot
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Routes");

            builder.HasKey(e => e.RouteId);

            builder.Property(e => e.RouteId)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
        }
    }
}