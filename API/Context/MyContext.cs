using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;


namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<TicketResponse> TicketResponses { get; set; }
        public DbSet<TicketResponseDetail> tickets { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Status-TicketStatus
            modelBuilder.Entity<TicketStatus>()
                .HasOne(TicketStatus => TicketStatus.Status)
                .WithMany(Status => Status.TicketStatuses);
            //Ticket-TicketStatus
            modelBuilder.Entity<TicketStatus>()
                .HasOne(TicketStatus => TicketStatus.Ticket)
                .WithMany(Ticket => Ticket.TicketStatuses);
            //Ticket-TicketMessage
            modelBuilder.Entity<TicketMessage>()
                .HasOne(TicketMessages => TicketMessages.Ticket)
                .WithMany(Ticket => Ticket.TicketMessages);
            //Ticket-Categories
            modelBuilder.Entity<Ticket>()
                .HasOne(Ticket => Ticket.Category)
                .WithMany(Categories => Categories.Tickets);
            //TicketResponse-TicketResponseDetail
            modelBuilder.Entity<TicketResponseDetail>()
                .HasOne(TicketResponseDetail => TicketResponseDetail.TicketResponse)
                .WithOne(TicketResponse => TicketResponse.TicketResponseDetail)
                .HasForeignKey<TicketResponseDetail>(TicketResponseDetail => TicketResponseDetail.ID);
            //Ticket-TicketResponse
            modelBuilder.Entity<TicketResponse>()
                .HasOne(TicketResponse => TicketResponse.Ticket)
                .WithMany(Ticket => Ticket.TicketResponses);
            //Client-Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(Ticket => Ticket.Client)
                .WithMany(Client => Client.Tickets);
            //Client-Account
            modelBuilder.Entity<Account>()
                .HasOne(Account => Account.Client)
                .WithOne(Client => Client.Account)
                .HasForeignKey<Account>(Account => Account.ID);
            //TicketResponse-Employee
            modelBuilder.Entity<TicketResponse>()
                .HasOne(TicketResponse => TicketResponse.Employee)
                .WithMany(Employee => Employee.TicketResponses);
            //Client-Account
            modelBuilder.Entity<Account>()
                .HasOne(Account => Account.Employee)
                .WithOne(Employee => Employee.Account)
                .HasForeignKey<Account>(Account => Account.ID);
            //Department-Employee
            modelBuilder.Entity<Employee>()
                .HasOne(Employee => Employee.Department)
                .WithMany(Department => Department.Employees);
            //Employee-EmployeeRole
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Employee)
                .WithMany(Employee => Employee.EmployeeRoles);
            //Role-EmployeeRole
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(EmployeeRole => EmployeeRole.Role)
                .WithMany(Role => Role.EmployeeRoles);
        }
    }
}
