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
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<TicketResponse> TicketResponses { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Status-TicketStatus
            modelBuilder.Entity<TicketStatus>()
                .HasOne(TicketStatus => TicketStatus.Status)
                .WithMany(Status => Status.TicketStatus);
            //Ticket-TicketStatus
            modelBuilder.Entity<TicketStatus>()
                .HasOne(TicketStatus => TicketStatus.Ticket)
                .WithMany(Ticket => Ticket.TicketStatuses);
            //Ticket-TicketMessage
            modelBuilder.Entity<TicketMessage>()
                .HasOne(TicketMessages => TicketMessages.Ticket)
                .WithMany(Ticket => Ticket.TicketMessages);
            //Categories-Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(Ticket => Ticket.Categories)
                .WithMany(Categories => Categories.Ticket);
            //Ticket-TicketResponse
            modelBuilder.Entity<TicketResponse>()
                .HasOne(TicketResponse => TicketResponse.Ticket)
                .WithMany(Ticket => Ticket.TicketResponses);
            //Employee-Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(Ticket => Ticket.Employee)
                .WithMany(Employee => Employee.Tickets);
            //Client-ClientAccount
            modelBuilder.Entity<Account>()
                .HasOne(Account => Account.Employee)
                .WithOne(Employee => Employee.Account)
                .HasForeignKey<Account>(Account => Account.Id);
            //Employee email Unique
            modelBuilder.Entity<Employee>()
                .HasIndex(employee => employee.Email)
                .IsUnique();
            ////User-UserAccount
            //modelBuilder.Entity<UserAccount>()
            //    .HasOne(Account => Account.User)
            //    .WithOne(Client => Client.UserAccount)
            //    .HasForeignKey<UserAccount>(Account => Account.Id);
            //Department-Employee
            modelBuilder.Entity<Employee>()
                .HasOne(Employee => Employee.Department)
                .WithMany(Department => Department.Employee);
            //Employee-EmployeeRole
            modelBuilder.Entity<Employee>()
                .HasOne(Employee => Employee.Role)
                .WithMany(Role => Role.Employee);
        }
    }
}
