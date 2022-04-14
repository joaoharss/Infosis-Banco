using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infosis_Banco.Migrations
{
    public partial class InfosisControle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractModalitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractModalitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitTypeId = table.Column<int>(type: "int", nullable: false),
                    NivelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_BenefitTypes_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Benefits_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModalityOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    ContractModalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalityOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModalityOffices_ContractModalitys_ContractModalityId",
                        column: x => x.ContractModalityId,
                        principalTable: "ContractModalitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalityOffices_Niveis_NivelId",
                        column: x => x.NivelId,
                        principalTable: "Niveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModalityOffices_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<long>(type: "bigint", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<long>(type: "bigint", nullable: false),
                    ModalityOfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_ModalityOffices_ModalityOfficeId",
                        column: x => x.ModalityOfficeId,
                        principalTable: "ModalityOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositVerifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Matureness = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositVerifications_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositVerifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositEmployeeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositVerificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_DepositVerifications_DepositVerificationId",
                        column: x => x.DepositVerificationId,
                        principalTable: "DepositVerifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BenefitTypeId",
                table: "Benefits",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_NivelId",
                table: "Benefits",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_DepositVerificationId",
                table: "Deposits",
                column: "DepositVerificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositVerifications_BenefitId",
                table: "DepositVerifications",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositVerifications_EmployeeId",
                table: "DepositVerifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ModalityOfficeId",
                table: "Employees",
                column: "ModalityOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalityOffices_ContractModalityId",
                table: "ModalityOffices",
                column: "ContractModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalityOffices_NivelId",
                table: "ModalityOffices",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_ModalityOffices_OfficeId",
                table: "ModalityOffices",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "DepositVerifications");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "BenefitTypes");

            migrationBuilder.DropTable(
                name: "ModalityOffices");

            migrationBuilder.DropTable(
                name: "ContractModalitys");

            migrationBuilder.DropTable(
                name: "Niveis");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
