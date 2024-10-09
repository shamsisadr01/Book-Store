using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.L3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    ALTER TABLE [dbo].UserRole
                    ADD CONSTRAINT FK_UserRole_Roles_RoleId
                    FOREIGN KEY (RoleId) REFERENCES [role].Roles(Id);
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
