using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class MigAlter6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaPagar_Proprietario_ProprietarioId",
                table: "ConsultaPagar");

            migrationBuilder.DropColumn(
                name: "IdProprietario",
                table: "ConsultaPagar");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarioId",
                table: "ConsultaPagar",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaPagar_Proprietario_ProprietarioId",
                table: "ConsultaPagar",
                column: "ProprietarioId",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaPagar_Proprietario_ProprietarioId",
                table: "ConsultaPagar");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarioId",
                table: "ConsultaPagar",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdProprietario",
                table: "ConsultaPagar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaPagar_Proprietario_ProprietarioId",
                table: "ConsultaPagar",
                column: "ProprietarioId",
                principalTable: "Proprietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
