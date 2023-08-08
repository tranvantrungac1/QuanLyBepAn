using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using QuanLyBepAn.Entities;

namespace QuanLyBepAn
{
    public class ApplicationDbContext : DbContext
    {
        public static string ConnectionString = @"Data Source=10.36.0.36,1433;Initial Catalog=TRUNGTV_BEPAN;User Id=trungtv;Password=Abcd@12345;TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: ConnectionString);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
    }
}
