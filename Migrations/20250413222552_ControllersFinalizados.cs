using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraApi.Migrations
{
    /// <inheritdoc />
    public partial class ControllersFinalizados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_ReferenciaModeloId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Carros_IdentificadorCarroId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_IdentificadorUsuarioId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_ReferenciaMarcaId",
                table: "Modelos");

            migrationBuilder.AlterColumn<string>(
                name: "NomeModelo",
                table: "Modelos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMarca",
                table: "Marcas",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Locacoes",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_ReferenciaModeloId",
                table: "Carros",
                column: "ReferenciaModeloId",
                principalTable: "Modelos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Carros_IdentificadorCarroId",
                table: "Locacoes",
                column: "IdentificadorCarroId",
                principalTable: "Carros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_IdentificadorUsuarioId",
                table: "Locacoes",
                column: "IdentificadorUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_ReferenciaMarcaId",
                table: "Modelos",
                column: "ReferenciaMarcaId",
                principalTable: "Marcas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_ReferenciaModeloId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Carros_IdentificadorCarroId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_IdentificadorUsuarioId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_ReferenciaMarcaId",
                table: "Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "NomeModelo",
                table: "Modelos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NomeMarca",
                table: "Marcas",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Locacoes",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_ReferenciaModeloId",
                table: "Carros",
                column: "ReferenciaModeloId",
                principalTable: "Modelos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Carros_IdentificadorCarroId",
                table: "Locacoes",
                column: "IdentificadorCarroId",
                principalTable: "Carros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_IdentificadorUsuarioId",
                table: "Locacoes",
                column: "IdentificadorUsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_ReferenciaMarcaId",
                table: "Modelos",
                column: "ReferenciaMarcaId",
                principalTable: "Marcas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
