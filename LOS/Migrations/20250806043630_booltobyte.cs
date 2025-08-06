using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LOS.Migrations
{
    /// <inheritdoc />
    public partial class booltobyte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "Users",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "Roles",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "rejectionReasons",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "pincodes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "occupationTypes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "employementTypes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "documentTypes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "departments",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "cities",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "banks",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "rejectionReasons",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "pincodes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "occupationTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "employementTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "documentTypes",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "departments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "cities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "banks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
