using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LOS.Migrations
{
    /// <inheritdoc />
    public partial class document : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_documentTypes",
                table: "documentTypes");

            migrationBuilder.RenameTable(
                name: "documentTypes",
                newName: "DocumentType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "DocumentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "documentTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_documentTypes",
                table: "documentTypes",
                column: "DocumentTypeId");
        }
    }
}
