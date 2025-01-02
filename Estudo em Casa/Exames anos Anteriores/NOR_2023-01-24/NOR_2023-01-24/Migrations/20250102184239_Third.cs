using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOR_2023_01_24.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Proprietarios_ProprietarioId",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarioId",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Proprietarios_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Proprietarios_ProprietarioId",
                table: "Veiculos");

            migrationBuilder.AlterColumn<int>(
                name: "ProprietarioId",
                table: "Veiculos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Proprietarios_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id");
        }
    }
}
