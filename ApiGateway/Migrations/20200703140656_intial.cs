using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiGateway.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    DownstreamPathTemplate = table.Column<string>(nullable: true),
                    DownstreamScheme = table.Column<string>(nullable: true),
                    UpstreamPathTemplate = table.Column<string>(nullable: true),
                    UpstreamHttpMethod = table.Column<List<string>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationOptions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AuthenticationProviderKey = table.Column<string>(nullable: true),
                    AllowedScopes = table.Column<List<string>>(nullable: true),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthenticationOptions_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownstreamHostAndPorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Host = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownstreamHostAndPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownstreamHostAndPorts_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadBalancerOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadBalancerOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadBalancerOptions_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationOptions_RouteId",
                table: "AuthenticationOptions",
                column: "RouteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DownstreamHostAndPorts_RouteId",
                table: "DownstreamHostAndPorts",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadBalancerOptions_RouteId",
                table: "LoadBalancerOptions",
                column: "RouteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationOptions");

            migrationBuilder.DropTable(
                name: "DownstreamHostAndPorts");

            migrationBuilder.DropTable(
                name: "GlobalConfigurations");

            migrationBuilder.DropTable(
                name: "LoadBalancerOptions");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
