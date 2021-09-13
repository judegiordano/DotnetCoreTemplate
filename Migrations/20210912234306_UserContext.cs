using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTemplate.Migrations
{
    public partial class UserContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Password_PasswordId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Password",
                table: "Password");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Password",
                newName: "Passwords");

            migrationBuilder.RenameIndex(
                name: "IX_User_PasswordId",
                table: "Users",
                newName: "IX_Users_PasswordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passwords",
                table: "Passwords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users",
                column: "PasswordId",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passwords",
                table: "Passwords");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Passwords",
                newName: "Password");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PasswordId",
                table: "User",
                newName: "IX_User_PasswordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Password",
                table: "Password",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Password_PasswordId",
                table: "User",
                column: "PasswordId",
                principalTable: "Password",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
