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
        public DbSet<AccountEmployee> AccountEmployees { get; set; }
        public DbSet<AccountClient> AccountClients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
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
            modelBuilder.Entity<Client>()
                .HasOne(client => client.AccountClient)
                .WithOne(accountClient => accountClient.Client)
                .HasForeignKey<AccountClient>(accountClient => accountClient.ID);
            //TicketResponse-Employee
            modelBuilder.Entity<TicketResponse>()
                .HasOne(TicketResponse => TicketResponse.Employee)
                .WithMany(Employee => Employee.TicketResponses);
            //Employee-Account
            modelBuilder.Entity<Employee>()
                .HasOne(employee => employee.AccountEmployee)
                .WithOne(accountEmployee => accountEmployee.Employee)
                .HasForeignKey<AccountEmployee>(accountEmployee => accountEmployee.ID);
            //Employee-Role
            modelBuilder.Entity<Employee>()
                .HasOne(Employee => Employee.Role)
                .WithMany(Role => Role.Employee);
            //Department-Employee
            modelBuilder.Entity<Employee>()
                .HasOne(Employee => Employee.Department)
                .WithMany(Department => Department.Employees);
   
        }
    }
}
