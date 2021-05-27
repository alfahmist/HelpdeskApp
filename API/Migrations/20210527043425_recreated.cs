using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class recreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.ID);
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
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_Client_TB_M_Account_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "TB_M_Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Account_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ClientID = table.Column<int>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "TB_M_EmployeeRole",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_EmployeeRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_EmployeeRole_TB_M_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "TB_M_Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_EmployeeRole_TB_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TB_M_Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_TicketMessage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    TicketID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_TicketMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_TicketMessage_TB_M_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "TB_M_Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_TicketResponse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<int>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_TicketResponse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_TicketResponse_TB_M_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "TB_M_Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_TicketResponse_TB_M_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "TB_M_Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_TicketStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    TicketID = table.Column<int>(nullable: true),
                    StatusID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_TicketStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_TicketStatus_TB_M_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "TB_M_Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_TicketStatus_TB_M_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "TB_M_Ticket",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_TicketResponseDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Solution = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_TicketResponseDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_M_TicketResponseDetail_TB_M_TicketResponse_ID",
                        column: x => x.ID,
                        principalTable: "TB_M_TicketResponse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_DepartmentID",
                table: "TB_M_Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_EmployeeRole_EmployeeID",
                table: "TB_M_EmployeeRole",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_EmployeeRole_RoleID",
                table: "TB_M_EmployeeRole",
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
                name: "IX_TB_M_TicketMessage_TicketID",
                table: "TB_M_TicketMessage",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_TicketResponse_EmployeeID",
                table: "TB_M_TicketResponse",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_TicketResponse_TicketID",
                table: "TB_M_TicketResponse",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_TicketStatus_StatusID",
                table: "TB_M_TicketStatus",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_TicketStatus_TicketID",
                table: "TB_M_TicketStatus",
                column: "TicketID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_EmployeeRole");

            migrationBuilder.DropTable(
                name: "TB_M_TicketMessage");

            migrationBuilder.DropTable(
                name: "TB_M_TicketResponseDetail");

            migrationBuilder.DropTable(
                name: "TB_M_TicketStatus");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_TicketResponse");

            migrationBuilder.DropTable(
                name: "TB_M_Status");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Ticket");

            migrationBuilder.DropTable(
                name: "TB_M_Department");

            migrationBuilder.DropTable(
                name: "TB_M_Category");

            migrationBuilder.DropTable(
                name: "TB_M_Client");

            migrationBuilder.DropTable(
                name: "TB_M_Account");
        }
    }
}
