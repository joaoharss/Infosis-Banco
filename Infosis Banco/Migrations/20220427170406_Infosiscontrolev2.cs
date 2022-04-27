using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infosis_Banco.Migrations
{
    public partial class Infosiscontrolev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficios_Niveis_NivelId",
                table: "Beneficios");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficios_TipoBeneficios_TipoBeneficioId",
                table: "Beneficios");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositoBeneficios_Beneficios_BeneficioId",
                table: "DepositoBeneficios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_ModalidadeCargos_ModalidadeCargoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ModalidadeCargos_Cargos_CargoId",
                table: "ModalidadeCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModalidadeCargos_ModalidadeContratos_ModalidadeContratoId",
                table: "ModalidadeCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModalidadeCargos_Niveis_NivelId",
                table: "ModalidadeCargos");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficios_Niveis_NivelId",
                table: "Beneficios",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficios_TipoBeneficios_TipoBeneficioId",
                table: "Beneficios",
                column: "TipoBeneficioId",
                principalTable: "TipoBeneficios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositoBeneficios_Beneficios_BeneficioId",
                table: "DepositoBeneficios",
                column: "BeneficioId",
                principalTable: "Beneficios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_ModalidadeCargos_ModalidadeCargoId",
                table: "Funcionarios",
                column: "ModalidadeCargoId",
                principalTable: "ModalidadeCargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModalidadeCargos_Cargos_CargoId",
                table: "ModalidadeCargos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModalidadeCargos_ModalidadeContratos_ModalidadeContratoId",
                table: "ModalidadeCargos",
                column: "ModalidadeContratoId",
                principalTable: "ModalidadeContratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModalidadeCargos_Niveis_NivelId",
                table: "ModalidadeCargos",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficios_Niveis_NivelId",
                table: "Beneficios");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficios_TipoBeneficios_TipoBeneficioId",
                table: "Beneficios");

            migrationBuilder.DropForeignKey(
                name: "FK_DepositoBeneficios_Beneficios_BeneficioId",
                table: "DepositoBeneficios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_ModalidadeCargos_ModalidadeCargoId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ModalidadeCargos_Cargos_CargoId",
                table: "ModalidadeCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModalidadeCargos_ModalidadeContratos_ModalidadeContratoId",
                table: "ModalidadeCargos");

            migrationBuilder.DropForeignKey(
                name: "FK_ModalidadeCargos_Niveis_NivelId",
                table: "ModalidadeCargos");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficios_Niveis_NivelId",
                table: "Beneficios",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficios_TipoBeneficios_TipoBeneficioId",
                table: "Beneficios",
                column: "TipoBeneficioId",
                principalTable: "TipoBeneficios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepositoBeneficios_Beneficios_BeneficioId",
                table: "DepositoBeneficios",
                column: "BeneficioId",
                principalTable: "Beneficios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_ModalidadeCargos_ModalidadeCargoId",
                table: "Funcionarios",
                column: "ModalidadeCargoId",
                principalTable: "ModalidadeCargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModalidadeCargos_Cargos_CargoId",
                table: "ModalidadeCargos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModalidadeCargos_ModalidadeContratos_ModalidadeContratoId",
                table: "ModalidadeCargos",
                column: "ModalidadeContratoId",
                principalTable: "ModalidadeContratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModalidadeCargos_Niveis_NivelId",
                table: "ModalidadeCargos",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
