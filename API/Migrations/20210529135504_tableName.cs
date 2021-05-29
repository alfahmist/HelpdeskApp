using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class tableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_ClientAccount_TB_M_Employee_Id",
                table: "TB_M_ClientAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_TicketStatus_TB_M_Status_StatusId",
                table: "TB_T_TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Status",
                table: "TB_M_Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_ClientAccount",
                table: "TB_M_ClientAccount");

            migrationBuilder.RenameTable(
                name: "TB_M_Status",
                newName: "TB_T_Status");

            migrationBuilder.RenameTable(
                name: "TB_M_ClientAccount",
                newName: "TB_M_Account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_Status",
                table: "TB_T_Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Account",
                table: "TB_M_Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Account_TB_M_Employee_Id",
                table: "TB_M_Account",
                column: "Id",
                principalTable: "TB_M_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_TicketStatus_TB_T_Status_StatusId",
                table: "TB_T_TicketStatus",
                column: "StatusId",
                principalTable: "TB_T_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Account_TB_M_Employee_Id",
                table: "TB_M_Account");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_TicketStatus_TB_T_Status_StatusId",
                table: "TB_T_TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_Status",
                table: "TB_T_Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_M_Account",
                table: "TB_M_Account");

            migrationBuilder.RenameTable(
                name: "TB_T_Status",
                newName: "TB_M_Status");

            migrationBuilder.RenameTable(
                name: "TB_M_Account",
                newName: "TB_M_ClientAccount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_Status",
                table: "TB_M_Status",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_M_ClientAccount",
                table: "TB_M_ClientAccount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_ClientAccount_TB_M_Employee_Id",
                table: "TB_M_ClientAccount",
                column: "Id",
                principalTable: "TB_M_Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_TicketStatus_TB_M_Status_StatusId",
                table: "TB_T_TicketStatus",
                column: "StatusId",
                principalTable: "TB_M_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
