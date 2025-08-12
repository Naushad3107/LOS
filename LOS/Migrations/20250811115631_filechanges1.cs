using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LOS.Migrations
{
    /// <inheritdoc />
    public partial class filechanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.DocumentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");

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
    }
}
