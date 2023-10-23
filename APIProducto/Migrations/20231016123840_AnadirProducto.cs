using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProducto.Migrations
{
    /// <inheritdoc />
    public partial class AnadirProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Cantidad", "Descripcion", "Nombre" },
                values: new object[] { 5, 12, "Descripcion 1", "Producto 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: 5);
        }
    }
}
