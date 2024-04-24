using Microsoft.EntityFrameworkCore;
using System.Windows;
using static КУРСАЧЧЧЧЧЧЧ.CREATE_TABLE;

public class BankingDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<ServiceResult> ServiceResults { get; set; }
    public DbSet<ServiceRequest> ServiceRequests { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=PC-232-09\\SQLEXPRESS;Database=BANK;Trusted_Connection=True;Encrypt=false;");
    }
}

