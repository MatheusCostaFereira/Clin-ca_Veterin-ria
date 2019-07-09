using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaVeterinaria.Migrations
{
    public partial class Mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Veterinario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Veterinario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Especialização",
                table: "Veterinario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Veterinario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamesRealizados",
                table: "Consulta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Veterinario");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Veterinario");

            migrationBuilder.DropColumn(
                name: "Especialização",
                table: "Veterinario");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Veterinario");

            migrationBuilder.DropColumn(
                name: "ExamesRealizados",
                table: "Consulta");
        }
    }
}
