using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pet_PetId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Veterinario_VeterinarioId",
                table: "Agenda");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarioId",
                table: "Agenda",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Agenda",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pet_PetId",
                table: "Agenda",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Veterinario_VeterinarioId",
                table: "Agenda",
                column: "VeterinarioId",
                principalTable: "Veterinario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Pet_PetId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Veterinario_VeterinarioId",
                table: "Agenda");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarioId",
                table: "Agenda",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Agenda",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Pet_PetId",
                table: "Agenda",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Veterinario_VeterinarioId",
                table: "Agenda",
                column: "VeterinarioId",
                principalTable: "Veterinario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
