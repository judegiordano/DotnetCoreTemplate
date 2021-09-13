using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTemplate.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PasswordId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Password",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginAttempts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PasswordId",
                table: "User",
                column: "PasswordId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Password_PasswordId",
                table: "User",
                column: "PasswordId",
                principalTable: "Password",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Password_PasswordId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Password");

            migrationBuilder.DropIndex(
                name: "IX_User_PasswordId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "Username",
                table: "User",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
