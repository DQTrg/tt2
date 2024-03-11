
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
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = Admin; database = dbCinema; Trusted_Connection = true; TrustServerCertificate = true");
    }
}
