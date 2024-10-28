using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locacoes.Migrations
{
    /// <inheritdoc />
    public partial class AddVeiculoLocacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VeiculoId",
                table: "Locacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeiculoIds",
                table: "Locacoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Veiculo_VeiculoId",
                table: "Locacoes",
                column: "VeiculoId",
                principalTable: "Veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Veiculo_VeiculoId",
                table: "Locacoes");

            migrationBuilder.DropIndex(
                name: "IX_Locacoes_VeiculoId",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "VeiculoIds",
                table: "Locacoes");

            migrationBuilder.AlterColumn<string>(
                name: "VeiculoId",
                table: "Locacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
