
using Microsoft.EntityFrameworkCore;
using TT2.Entity;

public class App_DBcontext : DbContext
{



    public DbSet<ConfirmEmail> ConfirmEmails { get; set; }

    public DbSet<RankCustomer> RankCustomers { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserStatus> UserStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=Admin;initial catalog=dbCinema;trusted_connection=true;TrustServerCertificate = true");
    }
}
