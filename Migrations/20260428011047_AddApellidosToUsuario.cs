using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexora.Migrations
{
    /// <inheritdoc />
    public partial class AddApellidosToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Usuarios",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "RUT",
                table: "Empresas",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Empresas",
                newName: "Telefono");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Empresas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Empresas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "Empresas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "Empresas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "Empresas");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Usuarios",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "Empresas",
                newName: "RUT");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Empresas",
                newName: "Nombre");
        }
    }
}
