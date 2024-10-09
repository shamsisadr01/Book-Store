using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.L3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "Roles",
                newSchema: "user");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserId",
                schema: "user",
                table: "Roles",
                newName: "IX_Roles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "user",
                table: "Roles",
                columns: new[] { "UserId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                schema: "user",
                table: "Roles",
                column: "UserId",
                principalSchema: "user",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                schema: "user",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "user",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "user",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_UserId",
                table: "UserRole",
                newName: "IX_UserRole_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Users_UserId",
                table: "UserRole",
                column: "UserId",
                principalSchema: "user",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
