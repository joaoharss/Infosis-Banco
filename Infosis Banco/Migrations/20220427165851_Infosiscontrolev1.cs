using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infosis_Banco.Migrations
{
    public partial class Infosiscontrolev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadeContratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadeContratos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoBeneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTipoBeneficio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PorcentagemPadrao = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBeneficios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModalidadeCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeContratoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalidadeCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModalidadeCargos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalidadeCargos_ModalidadeContratos_ModalidadeContratoId",
                        column: x => x.ModalidadeContratoId,
                        principalTable: "ModalidadeContratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalidadeCargos_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoBeneficioId = table.Column<int>(type: "int", nullable: false),
                    NivelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficios_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficios_TipoBeneficios_TipoBeneficioId",
                        column: x => x.TipoBeneficioId,
                        principalTable: "TipoBeneficios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<long>(type: "bigint", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<long>(type: "bigint", nullable: false),
                    ModalidadeCargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_ModalidadeCargos_ModalidadeCargoId",
                        column: x => x.ModalidadeCargoId,
                        principalTable: "ModalidadeCargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositoBeneficios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorDepositoBeneficio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeneficioId = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositoBeneficios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositoBeneficios_Beneficios_BeneficioId",
                        column: x => x.BeneficioId,
                        principalTable: "Beneficios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositoBeneficios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorDepositoFuncionario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositoBeneficioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depositos_DepositoBeneficios_DepositoBeneficioId",
                        column: x => x.DepositoBeneficioId,
                        principalTable: "DepositoBeneficios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficios_NivelId",
                table: "Beneficios",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficios_TipoBeneficioId",
                table: "Beneficios",
                column: "TipoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositoBeneficios_BeneficioId",
                table: "DepositoBeneficios",
                column: "BeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositoBeneficios_FuncionarioId",
                table: "DepositoBeneficios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_DepositoBeneficioId",
                table: "Depositos",
                column: "DepositoBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ModalidadeCargoId",
                table: "Funcionarios",
                column: "ModalidadeCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadeCargos_CargoId",
                table: "ModalidadeCargos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadeCargos_ModalidadeContratoId",
                table: "ModalidadeCargos",
                column: "ModalidadeContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalidadeCargos_NivelId",
                table: "ModalidadeCargos",
                column: "NivelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DropTable(
                name: "DepositoBeneficios");

            migrationBuilder.DropTable(
                name: "Beneficios");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "TipoBeneficios");

            migrationBuilder.DropTable(
                name: "ModalidadeCargos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "ModalidadeContratos");

            migrationBuilder.DropTable(
                name: "Niveis");
        }
    }
}
