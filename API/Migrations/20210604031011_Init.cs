using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TB_M_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employee_Id",
                        column: x => x.Id,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_Ticket",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CategoriesId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_Ticket_TB_M_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "TB_M_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_T_Ticket_TB_M_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_TicketMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_TicketMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_TicketMessage_TB_T_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "TB_T_Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_TicketResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    ResponDate = table.Column<DateTime>(nullable: false),
                    Solution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_TicketResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_TicketResponse_TB_M_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_M_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_T_TicketResponse_TB_T_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "TB_T_Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_TicketStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    TicketId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_TicketStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_T_TicketStatus_TB_M_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TB_M_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_T_TicketStatus_TB_T_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "TB_T_Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_DepartmentId",
                table: "TB_M_Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_Email",
                table: "TB_M_Employee",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_RoleId",
                table: "TB_M_Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Ticket_CategoriesId",
                table: "TB_T_Ticket",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_Ticket_EmployeeId",
                table: "TB_T_Ticket",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TicketMessage_TicketId",
                table: "TB_T_TicketMessage",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TicketResponse_EmployeeId",
                table: "TB_T_TicketResponse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TicketResponse_TicketId",
                table: "TB_T_TicketResponse",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TicketStatus_StatusId",
                table: "TB_T_TicketStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_TicketStatus_TicketId",
                table: "TB_T_TicketStatus",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_T_TicketMessage");

            migrationBuilder.DropTable(
                name: "TB_T_TicketResponse");

            migrationBuilder.DropTable(
                name: "TB_T_TicketStatus");

            migrationBuilder.DropTable(
                name: "TB_M_Status");

            migrationBuilder.DropTable(
                name: "TB_T_Ticket");

            migrationBuilder.DropTable(
                name: "TB_M_Categories");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Department");

            migrationBuilder.DropTable(
                name: "TB_M_Role");
        }
    }
}
