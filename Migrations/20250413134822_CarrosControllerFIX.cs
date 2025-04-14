using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraApi.Migrations
{
    /// <inheritdoc />
    public partial class CarrosControllerFIX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_ReferenciaModeloCodigo",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Carros_IdentificadorCarroCodigo",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_IdentificadorUsuarioCodigo",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_ReferenciaMarcaCodigo",
                table: "Modelos");

            migrationBuilder.RenameColumn(
                name: "ReferenciaMarcaCodigo",
                table: "Modelos",
                newName: "ReferenciaMarcaId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Modelos",
                newName: "NomeModelo");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_ReferenciaMarcaCodigo",
                table: "Modelos",
                newName: "IX_Modelos_ReferenciaMarcaId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Marcas",
                newName: "NomeMarca");

            migrationBuilder.RenameColumn(
                name: "IdentificadorUsuarioCodigo",
                table: "Locacoes",
                newName: "IdentificadorUsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdentificadorCarroCodigo",
                table: "Locacoes",
                newName: "IdentificadorCarroId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_IdentificadorUsuarioCodigo",
                table: "Locacoes",
                newName: "IX_Locacoes_IdentificadorUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_IdentificadorCarroCodigo",
                table: "Locacoes",
                newName: "IX_Locacoes_IdentificadorCarroId");

            migrationBuilder.RenameColumn(
                name: "ReferenciaModeloCodigo",
                table: "Carros",
                newName: "ReferenciaModeloId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Carros",
                newName: "DescricaoCarro");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_ReferenciaModeloCodigo",
                table: "Carros",
                newName: "IX_Carros_ReferenciaModeloId");

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

            migrationBuilder.RenameColumn(
                name: "ReferenciaMarcaId",
                table: "Modelos",
                newName: "ReferenciaMarcaCodigo");

            migrationBuilder.RenameColumn(
                name: "NomeModelo",
                table: "Modelos",
                newName: "Descricao");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_ReferenciaMarcaId",
                table: "Modelos",
                newName: "IX_Modelos_ReferenciaMarcaCodigo");

            migrationBuilder.RenameColumn(
                name: "NomeMarca",
                table: "Marcas",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "IdentificadorUsuarioId",
                table: "Locacoes",
                newName: "IdentificadorUsuarioCodigo");

            migrationBuilder.RenameColumn(
                name: "IdentificadorCarroId",
                table: "Locacoes",
                newName: "IdentificadorCarroCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_IdentificadorUsuarioId",
                table: "Locacoes",
                newName: "IX_Locacoes_IdentificadorUsuarioCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_IdentificadorCarroId",
                table: "Locacoes",
                newName: "IX_Locacoes_IdentificadorCarroCodigo");

            migrationBuilder.RenameColumn(
                name: "ReferenciaModeloId",
                table: "Carros",
                newName: "ReferenciaModeloCodigo");

            migrationBuilder.RenameColumn(
                name: "DescricaoCarro",
                table: "Carros",
                newName: "Descricao");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_ReferenciaModeloId",
                table: "Carros",
                newName: "IX_Carros_ReferenciaModeloCodigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_ReferenciaModeloCodigo",
                table: "Carros",
                column: "ReferenciaModeloCodigo",
                principalTable: "Modelos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Carros_IdentificadorCarroCodigo",
                table: "Locacoes",
                column: "IdentificadorCarroCodigo",
                principalTable: "Carros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_IdentificadorUsuarioCodigo",
                table: "Locacoes",
                column: "IdentificadorUsuarioCodigo",
                principalTable: "Usuarios",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_ReferenciaMarcaCodigo",
                table: "Modelos",
                column: "ReferenciaMarcaCodigo",
                principalTable: "Marcas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
