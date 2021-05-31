using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateStatusTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_TicketStatus_TB_T_Status_StatusId",
                table: "TB_T_TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_Status",
                table: "TB_T_Status");

            migrationBuilder.RenameTable(
                name: "TB_T_Status",
                newName: "TB_M_Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Status",
                table: "TB_M_Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_TicketStatus_TB_M_Status_StatusId",
                table: "TB_T_TicketStatus",
                column: "StatusId",
                principalTable: "TB_M_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_TicketStatus_TB_M_Status_StatusId",
                table: "TB_T_TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Status",
                table: "TB_M_Status");

            migrationBuilder.RenameTable(
                name: "TB_M_Status",
                newName: "TB_T_Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_Status",
                table: "TB_T_Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_TicketStatus_TB_T_Status_StatusId",
                table: "TB_T_TicketStatus",
                column: "StatusId",
                principalTable: "TB_T_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
