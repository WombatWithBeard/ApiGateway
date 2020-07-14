﻿// <auto-generated />
using Infrastructure.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiGateway.Migrations
{
    [DbContext(typeof(ApiGatewayDbContext))]
    [Migration("20200713141641_RouteClaims")]
    partial class RouteClaims
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entities.Common.Scope", b =>
                {
                    b.Property<int>("ScopeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("AuthenticationOptionId")
                        .HasColumnType("integer");

                    b.Property<int>("ExternalId")
                        .HasColumnType("integer");

                    b.Property<string>("ScopeName")
                        .HasColumnType("text");

                    b.HasKey("ScopeId");

                    b.HasIndex("AuthenticationOptionId");

                    b.ToTable("Scopes");

                    b.HasData(
                        new
                        {
                            ScopeId = 1,
                            AuthenticationOptionId = 1,
                            ExternalId = 1,
                            ScopeName = "ApiOne"
                        },
                        new
                        {
                            ScopeId = 2,
                            AuthenticationOptionId = 1,
                            ExternalId = 2,
                            ScopeName = "ApiTwo"
                        },
                        new
                        {
                            ScopeId = 3,
                            AuthenticationOptionId = 2,
                            ExternalId = 1,
                            ScopeName = "ApiOne"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Common.UpstreamHttpsMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("UpstreamHttpsMethods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Get",
                            RouteId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Post",
                            RouteId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Put",
                            RouteId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delete",
                            RouteId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Get",
                            RouteId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Routes.AuthenticationOption", b =>
                {
                    b.Property<int>("AuthenticationOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("AuthenticationProviderKey")
                        .HasColumnType("text");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("AuthenticationOptionId");

                    b.HasIndex("RouteId")
                        .IsUnique();

                    b.ToTable("AuthenticationOptions");

                    b.HasData(
                        new
                        {
                            AuthenticationOptionId = 1,
                            AuthenticationProviderKey = "TestKey",
                            RouteId = 1
                        },
                        new
                        {
                            AuthenticationOptionId = 2,
                            AuthenticationProviderKey = "TestKey",
                            RouteId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Routes.DownstreamHostAndPort", b =>
                {
                    b.Property<int>("DownstreamHostAndPortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Host")
                        .HasColumnType("text");

                    b.Property<int>("Port")
                        .HasColumnType("integer");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("DownstreamHostAndPortId");

                    b.HasIndex("RouteId");

                    b.ToTable("DownstreamHostAndPorts");

                    b.HasData(
                        new
                        {
                            DownstreamHostAndPortId = 1,
                            Host = "localhost",
                            Port = 3001,
                            RouteId = 1
                        },
                        new
                        {
                            DownstreamHostAndPortId = 2,
                            Host = "localhost",
                            Port = 3010,
                            RouteId = 1
                        },
                        new
                        {
                            DownstreamHostAndPortId = 3,
                            Host = "localhost",
                            Port = 4003,
                            RouteId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Routes.GlobalConfiguration", b =>
                {
                    b.Property<int>("GlobalConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("BaseUrl")
                        .HasColumnType("text");

                    b.HasKey("GlobalConfigurationId");

                    b.ToTable("GlobalConfigurations");

                    b.HasData(
                        new
                        {
                            GlobalConfigurationId = 1,
                            BaseUrl = "https://localhost:6900"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Routes.LoadBalancerOption", b =>
                {
                    b.Property<int>("LoadBalancerOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("LoadBalancerOptionId");

                    b.HasIndex("RouteId")
                        .IsUnique();

                    b.ToTable("LoadBalancerOptions");

                    b.HasData(
                        new
                        {
                            LoadBalancerOptionId = 1,
                            RouteId = 1,
                            Type = "RoundRobin"
                        },
                        new
                        {
                            LoadBalancerOptionId = 2,
                            RouteId = 2,
                            Type = "RoundRobin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Routes.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("DownstreamPathTemplate")
                        .HasColumnType("text");

                    b.Property<string>("DownstreamScheme")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("UpstreamPathTemplate")
                        .HasColumnType("text");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            RouteId = 1,
                            DownstreamPathTemplate = "/{url}",
                            DownstreamScheme = "https",
                            Enabled = true,
                            Priority = 0,
                            UpstreamPathTemplate = "/ServiceOne/{url}"
                        },
                        new
                        {
                            RouteId = 2,
                            DownstreamPathTemplate = "/{url}",
                            DownstreamScheme = "https",
                            Enabled = true,
                            Priority = 0,
                            UpstreamPathTemplate = "/ServiceTwo/{url}"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Routes.RouteClaimsRequirement", b =>
                {
                    b.Property<int>("RouteClaimsRequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("RouteClaimsRequirementId");

                    b.HasIndex("RouteId")
                        .IsUnique();

                    b.ToTable("RouteClaimsRequirements");
                });

            modelBuilder.Entity("Domain.Entities.Common.Scope", b =>
                {
                    b.HasOne("Domain.Entities.Routes.AuthenticationOption", null)
                        .WithMany("AllowedScopes")
                        .HasForeignKey("AuthenticationOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Common.UpstreamHttpsMethod", b =>
                {
                    b.HasOne("Domain.Entities.Routes.Route", null)
                        .WithMany("UpstreamHttpMethod")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Routes.AuthenticationOption", b =>
                {
                    b.HasOne("Domain.Entities.Routes.Route", null)
                        .WithOne("AuthenticationOptions")
                        .HasForeignKey("Domain.Entities.Routes.AuthenticationOption", "RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Routes.DownstreamHostAndPort", b =>
                {
                    b.HasOne("Domain.Entities.Routes.Route", null)
                        .WithMany("DownstreamHostAndPorts")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Routes.LoadBalancerOption", b =>
                {
                    b.HasOne("Domain.Entities.Routes.Route", null)
                        .WithOne("LoadBalancerOptions")
                        .HasForeignKey("Domain.Entities.Routes.LoadBalancerOption", "RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Routes.RouteClaimsRequirement", b =>
                {
                    b.HasOne("Domain.Entities.Routes.Route", null)
                        .WithOne("RouteClaimsRequirement")
                        .HasForeignKey("Domain.Entities.Routes.RouteClaimsRequirement", "RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}