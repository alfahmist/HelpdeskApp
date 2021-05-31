using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Client",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_Client_TB_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TB_M_Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TB_M_Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_AccountClient",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_AccountClient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_AccountClient_TB_M_Client_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_AccountEmployee",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_AccountEmployee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_AccountEmployee_TB_M_Employee_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Ticket",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ClientID = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ClosedDate = table.Column<DateTime>(nullable: true),
                    StatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_Ticket_TB_M_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "TB_M_Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Ticket_TB_M_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "TB_M_Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Ticket_TB_M_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "TB_M_Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Ticket_TB_M_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "TB_M_Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_ClientMessage",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_ClientMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_ClientMessage_TB_M_Ticket_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Response",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Response", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_Response_TB_M_Ticket_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Client_RoleID",
                table: "TB_M_Client",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_RoleID",
                table: "TB_M_Employee",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Ticket_CategoryID",
                table: "TB_M_Ticket",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Ticket_ClientID",
                table: "TB_M_Ticket",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Ticket_EmployeeID",
                table: "TB_M_Ticket",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Ticket_StatusID",
                table: "TB_M_Ticket",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_AccountClient");

            migrationBuilder.DropTable(
                name: "TB_M_AccountEmployee");

            migrationBuilder.DropTable(
                name: "TB_M_ClientMessage");

            migrationBuilder.DropTable(
                name: "TB_M_Response");

            migrationBuilder.DropTable(
                name: "TB_M_Ticket");

            migrationBuilder.DropTable(
                name: "TB_M_Category");

            migrationBuilder.DropTable(
                name: "TB_M_Client");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Status");

            migrationBuilder.DropTable(
                name: "TB_M_Role");
        }
    }
}
