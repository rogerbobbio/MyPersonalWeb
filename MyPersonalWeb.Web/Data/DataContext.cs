using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPersonalWeb.Web.Data.Entities;

namespace MyPersonalWeb.Web.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<UserManager> UserManagers { get; set; }
        public DbSet<PlayerType> PlayerTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionRol> PositionRols { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
