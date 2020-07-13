using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiGateway.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BaseUrl = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_GlobalConfigurations", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    DownstreamPathTemplate = table.Column<string>(nullable: true),
                    DownstreamScheme = table.Column<string>(nullable: true),
                    UpstreamPathTemplate = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Routes", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "AuthenticationOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthenticationProviderKey = table.Column<string>(nullable: true),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "UpstreamHttpsMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpstreamHttpsMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpstreamHttpsMethods_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ExternalId = table.Column<int>(nullable: false),
                    ScopeName = table.Column<string>(nullable: true),
                    AuthenticationOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scopes_AuthenticationOptions_AuthenticationOptionId",
                        column: x => x.AuthenticationOptionId,
                        principalTable: "AuthenticationOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GlobalConfigurations",
                columns: new[] {"Id", "BaseUrl"},
                values: new object[] {1, "https://localhost:6900"});

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[]
                    {"Id", "DownstreamPathTemplate", "DownstreamScheme", "Enabled", "Priority", "UpstreamPathTemplate"},
                values: new object[,]
                {
                    {1, "/{url}", "https", true, 0, "/ServiceOne/{url}"},
                    {2, "/{url}", "https", true, 0, "/ServiceTwo/{url}"}
                });

            migrationBuilder.InsertData(
                table: "AuthenticationOptions",
                columns: new[] {"Id", "AuthenticationProviderKey", "RouteId"},
                values: new object[,]
                {
                    {1, "TestKey", 1},
                    {2, "TestKey", 2}
                });

            migrationBuilder.InsertData(
                table: "DownstreamHostAndPorts",
                columns: new[] {"Id", "Host", "Port", "RouteId"},
                values: new object[,]
                {
                    {1, "localhost", 3001, 1},
                    {2, "localhost", 3010, 1},
                    {3, "localhost", 4003, 2}
                });

            migrationBuilder.InsertData(
                table: "LoadBalancerOptions",
                columns: new[] {"Id", "RouteId", "Type"},
                values: new object[,]
                {
                    {1, 1, "RoundRobin"},
                    {2, 2, "RoundRobin"}
                });

            migrationBuilder.InsertData(
                table: "UpstreamHttpsMethods",
                columns: new[] {"Id", "Name", "RouteId"},
                values: new object[,]
                {
                    {1, "Get", 1},
                    {2, "Post", 1},
                    {3, "Put", 1},
                    {4, "Delete", 1},
                    {5, "Get", 2}
                });

            migrationBuilder.InsertData(
                table: "Scopes",
                columns: new[] {"Id", "AuthenticationOptionId", "ExternalId", "ScopeName"},
                values: new object[,]
                {
                    {1, 1, 1, "ApiOne"},
                    {2, 1, 2, "ApiTwo"},
                    {3, 2, 1, "ApiOne"}
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

            migrationBuilder.CreateIndex(
                name: "IX_Scopes_AuthenticationOptionId",
                table: "Scopes",
                column: "AuthenticationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UpstreamHttpsMethods_RouteId",
                table: "UpstreamHttpsMethods",
                column: "RouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DownstreamHostAndPorts");

            migrationBuilder.DropTable(
                name: "GlobalConfigurations");

            migrationBuilder.DropTable(
                name: "LoadBalancerOptions");

            migrationBuilder.DropTable(
                name: "Scopes");

            migrationBuilder.DropTable(
                name: "UpstreamHttpsMethods");

            migrationBuilder.DropTable(
                name: "AuthenticationOptions");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}