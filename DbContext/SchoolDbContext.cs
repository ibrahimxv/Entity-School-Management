namespace ConsoleApp23.DbContext;

using ConsoleApp23.Entity;
using Microsoft.EntityFrameworkCore;

public class SchoolDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("server=TITAN006\\SQLEXPRESS;database=SchoolManagement;trusted_connection=true;integrated security=true;TrustServerCertificate=true;");
    }
    public DbSet<Students> Students { get; set; }
}

        