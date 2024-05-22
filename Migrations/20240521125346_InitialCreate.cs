using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImobSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Interesse = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoImovel = table.Column<string>(type: "TEXT", nullable: false),
                    ValorImovel = table.Column<decimal>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fases = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    FaseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFases_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cep = table.Column<string>(type: "TEXT", nullable: false),
                    logradouro = table.Column<string>(type: "TEXT", nullable: false),
                    numero = table.Column<string>(type: "TEXT", nullable: false),
                    complemento = table.Column<string>(type: "TEXT", nullable: false),
                    bairro = table.Column<string>(type: "TEXT", nullable: false),
                    cidade = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false),
                    ValorImovel = table.Column<decimal>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorProposal = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorContraProposal = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposals_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitHouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitHouses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitHouses_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDoc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modalidade = table.Column<string>(type: "TEXT", nullable: false),
                    DataVistoria = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataContrato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEscritura = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProposalId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formalizations_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFases_ClientId",
                table: "ClientFases",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFases_FaseId",
                table: "ClientFases",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientId",
                table: "ClientServices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Formalizations_ProposalId",
                table: "Formalizations",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_ClientId",
                table: "Proposals",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_HouseId",
                table: "Proposals",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitHouses_ClientId",
                table: "VisitHouses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitHouses_HouseId",
                table: "VisitHouses",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFases");

            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.DropTable(
                name: "Formalizations");

            migrationBuilder.DropTable(
                name: "VisitHouses");

            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
