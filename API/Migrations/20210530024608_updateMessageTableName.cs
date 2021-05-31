using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateMessageTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_T_TicketMessage_TB_T_Ticket_TicketId",
                table: "Table_T_TicketMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Table_T_TicketMessage",
                table: "Table_T_TicketMessage");

            migrationBuilder.RenameTable(
                name: "Table_T_TicketMessage",
                newName: "TB_T_TicketMessage");

            migrationBuilder.RenameIndex(
                name: "IX_Table_T_TicketMessage_TicketId",
                table: "TB_T_TicketMessage",
                newName: "IX_TB_T_TicketMessage_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_TicketMessage",
                table: "TB_T_TicketMessage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_T_TicketMessage_TB_T_Ticket_TicketId",
                table: "TB_T_TicketMessage",
                column: "TicketId",
                principalTable: "TB_T_Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_T_TicketMessage_TB_T_Ticket_TicketId",
                table: "TB_T_TicketMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_TicketMessage",
                table: "TB_T_TicketMessage");

            migrationBuilder.RenameTable(
                name: "TB_T_TicketMessage",
                newName: "Table_T_TicketMessage");

            migrationBuilder.RenameIndex(
                name: "IX_TB_T_TicketMessage_TicketId",
                table: "Table_T_TicketMessage",
                newName: "IX_Table_T_TicketMessage_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Table_T_TicketMessage",
                table: "Table_T_TicketMessage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Table_T_TicketMessage_TB_T_Ticket_TicketId",
                table: "Table_T_TicketMessage",
                column: "TicketId",
                principalTable: "TB_T_Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
