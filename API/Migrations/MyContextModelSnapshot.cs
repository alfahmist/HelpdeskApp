﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Account");
                });

            modelBuilder.Entity("API.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Category");
                });

            modelBuilder.Entity("API.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Client");
                });

            modelBuilder.Entity("API.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Department");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("TB_M_Employee");
                });

            modelBuilder.Entity("API.Models.EmployeeRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("TB_M_EmployeeRole");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Role");
                });

            modelBuilder.Entity("API.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StatusDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Status");
                });

            modelBuilder.Entity("API.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ClientID");

                    b.ToTable("TB_M_Ticket");
                });

            modelBuilder.Entity("API.Models.TicketMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TicketID");

                    b.ToTable("TB_M_TicketMessage");
                });

            modelBuilder.Entity("API.Models.TicketResponse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TicketID");

                    b.ToTable("TB_M_TicketResponse");
                });

            modelBuilder.Entity("API.Models.TicketResponseDetail", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TB_M_TicketResponseDetail");
                });

            modelBuilder.Entity("API.Models.TicketStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StatusID")
                        .HasColumnType("int");

                    b.Property<int?>("TicketID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TicketID");

                    b.ToTable("TB_M_TicketStatus");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Client", "Client")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasOne("API.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID");
                });

            modelBuilder.Entity("API.Models.EmployeeRole", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("EmployeeRoles")
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("API.Models.Ticket", b =>
                {
                    b.HasOne("API.Models.Category", "Category")
                        .WithMany("Tickets")
                        .HasForeignKey("CategoryID");

                    b.HasOne("API.Models.Client", "Client")
                        .WithMany("Tickets")
                        .HasForeignKey("ClientID");
                });

            modelBuilder.Entity("API.Models.TicketMessage", b =>
                {
                    b.HasOne("API.Models.Ticket", "Ticket")
                        .WithMany("TicketMessages")
                        .HasForeignKey("TicketID");
                });

            modelBuilder.Entity("API.Models.TicketResponse", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("TicketResponses")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("API.Models.Ticket", "Ticket")
                        .WithMany("TicketResponses")
                        .HasForeignKey("TicketID");
                });

            modelBuilder.Entity("API.Models.TicketResponseDetail", b =>
                {
                    b.HasOne("API.Models.TicketResponse", "TicketResponse")
                        .WithOne("TicketResponseDetail")
                        .HasForeignKey("API.Models.TicketResponseDetail", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.TicketStatus", b =>
                {
                    b.HasOne("API.Models.Status", "Status")
                        .WithMany("TicketStatuses")
                        .HasForeignKey("StatusID");

                    b.HasOne("API.Models.Ticket", "Ticket")
                        .WithMany("TicketStatuses")
                        .HasForeignKey("TicketID");
                });
#pragma warning restore 612, 618
        }
    }
}
