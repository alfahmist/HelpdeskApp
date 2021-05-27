using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EMPEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TB_M_Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "TB_M_Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TB_M_Employee");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "TB_M_Employee");
        }
    }
}
