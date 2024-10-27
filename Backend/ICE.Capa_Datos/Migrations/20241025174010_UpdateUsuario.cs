using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICE.Capa_Datos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubestacionId",
                table: "Usuario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UnidadRegionalId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UnidadRegionalId",
                table: "Usuario",
                column: "UnidadRegionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_UnidadRegional_UnidadRegionalId",
                table: "Usuario",
                column: "UnidadRegionalId",
                principalTable: "UnidadRegional",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_UnidadRegional_UnidadRegionalId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_UnidadRegionalId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UnidadRegionalId",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "SubestacionId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
