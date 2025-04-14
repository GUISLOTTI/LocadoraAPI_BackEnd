using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraApi.Migrations
{
    /// <inheritdoc />
    public partial class Ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Modelos_CodigoModelo",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Carros_CodigoCarro",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Usuarios_CodigoUsuario",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Marcas_CodigoMarca",
                table: "Modelos");

            migrationBuilder.RenameColumn(
                name: "CodigoMarca",
                table: "Modelos",
                newName: "ReferenciaMarcaCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_CodigoMarca",
                table: "Modelos",
                newName: "IX_Modelos_ReferenciaMarcaCodigo");

            migrationBuilder.RenameColumn(
                name: "CodigoUsuario",
                table: "Locacoes",
                newName: "IdentificadorUsuarioCodigo");

            migrationBuilder.RenameColumn(
                name: "CodigoCarro",
                table: "Locacoes",
                newName: "IdentificadorCarroCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_CodigoUsuario",
                table: "Locacoes",
                newName: "IX_Locacoes_IdentificadorUsuarioCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_CodigoCarro",
                table: "Locacoes",
                newName: "IX_Locacoes_IdentificadorCarroCodigo");

            migrationBuilder.RenameColumn(
                name: "CodigoModelo",
                table: "Carros",
                newName: "ReferenciaModeloCodigo");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_CodigoModelo",
                table: "Carros",
                newName: "IX_Carros_ReferenciaModeloCodigo");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentificadorUsuario",
                table: "Usuarios",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdentificadorCarro",
                table: "Carros",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IdentificadorUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdentificadorCarro",
                table: "Carros");

            migrationBuilder.RenameColumn(
                name: "ReferenciaMarcaCodigo",
                table: "Modelos",
                newName: "CodigoMarca");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_ReferenciaMarcaCodigo",
                table: "Modelos",
                newName: "IX_Modelos_CodigoMarca");

            migrationBuilder.RenameColumn(
                name: "IdentificadorUsuarioCodigo",
                table: "Locacoes",
                newName: "CodigoUsuario");

            migrationBuilder.RenameColumn(
                name: "IdentificadorCarroCodigo",
                table: "Locacoes",
                newName: "CodigoCarro");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_IdentificadorUsuarioCodigo",
                table: "Locacoes",
                newName: "IX_Locacoes_CodigoUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_IdentificadorCarroCodigo",
                table: "Locacoes",
                newName: "IX_Locacoes_CodigoCarro");

            migrationBuilder.RenameColumn(
                name: "ReferenciaModeloCodigo",
                table: "Carros",
                newName: "CodigoModelo");

            migrationBuilder.RenameIndex(
                name: "IX_Carros_ReferenciaModeloCodigo",
                table: "Carros",
                newName: "IX_Carros_CodigoModelo");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_Modelos_CodigoModelo",
                table: "Carros",
                column: "CodigoModelo",
                principalTable: "Modelos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Carros_CodigoCarro",
                table: "Locacoes",
                column: "CodigoCarro",
                principalTable: "Carros",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Usuarios_CodigoUsuario",
                table: "Locacoes",
                column: "CodigoUsuario",
                principalTable: "Usuarios",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Marcas_CodigoMarca",
                table: "Modelos",
                column: "CodigoMarca",
                principalTable: "Marcas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
