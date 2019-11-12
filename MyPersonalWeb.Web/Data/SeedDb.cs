using MyPersonalWeb.Web.Data.Entities;
using MyPersonalWeb.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalWeb.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("1010", "Roger", "Admin", "rogerbobbio@gmail.com", "350 634 2747", "Calle Luna Calle Sol", "Admin");
            //var customer = await CheckUserAsync("2020", "Roger", "Customer", "rogerbobbio@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", "Customer");
            await CheckManagerAsync(manager);
            await CheckPlayerTypesAsync();
            await CheckPositionsAsync();
            await CheckPositionRolesAsync();
            await CheckLeaguesAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            //await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task CheckPlayerTypesAsync()
        {
            if (!_dataContext.PlayerTypes.Any())
            {
                _dataContext.PlayerTypes.Add(new PlayerType { Name = "ORO" });
                _dataContext.PlayerTypes.Add(new PlayerType { Name = "PLATA" });
                _dataContext.PlayerTypes.Add(new PlayerType { Name = "BRONCE" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPositionsAsync()
        {
            if (!_dataContext.Positions.Any())
            {
                _dataContext.Positions.Add(new Position { Name = "PORTERO" });
                _dataContext.Positions.Add(new Position { Name = "DEFENSA" });
                _dataContext.Positions.Add(new Position { Name = "MEDIO" });
                _dataContext.Positions.Add(new Position { Name = "DELANTERO" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPositionRolesAsync()
        {
            if (!_dataContext.PositionRols.Any())
            {
                _dataContext.PositionRols.Add(new PositionRol { Name = "PO", PositionId = 1 });

                _dataContext.PositionRols.Add(new PositionRol { Name = "CB", PositionId = 2 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "DFI", PositionId = 2 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "DFD", PositionId = 2 });

                _dataContext.PositionRols.Add(new PositionRol { Name = "MCO", PositionId = 3 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "MC", PositionId = 3 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "MCD", PositionId = 3 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "MI", PositionId = 3 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "MD", PositionId = 3 });

                _dataContext.PositionRols.Add(new PositionRol { Name = "DC", PositionId = 4 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "ED", PositionId = 4 });
                _dataContext.PositionRols.Add(new PositionRol { Name = "EI", PositionId = 4 });
                
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckLeaguesAsync()
        {
            if (!_dataContext.Leagues.Any())
            {
                _dataContext.Leagues.Add(new League { Name = "ALEMANIA - Bundesliga" });
                _dataContext.Leagues.Add(new League { Name = "ALEMANIA - Bundesliga 2" });
                _dataContext.Leagues.Add(new League { Name = "ALEMANIA - 3 Liga" });
                _dataContext.Leagues.Add(new League { Name = "ESPANA - La Liga" });
                _dataContext.Leagues.Add(new League { Name = "ESPANA - La Liga 123" });
                _dataContext.Leagues.Add(new League { Name = "INGLATERRA - Premier" });
                _dataContext.Leagues.Add(new League { Name = "INGLATERRA - Efl Championship (2div)" });
                _dataContext.Leagues.Add(new League { Name = "INGLATERRA - Efl League One (3div)" });
                _dataContext.Leagues.Add(new League { Name = "INGLATERRA - Efl League Two (4div)" });
                _dataContext.Leagues.Add(new League { Name = "ITALIA - Serie A" });
                _dataContext.Leagues.Add(new League { Name = "ITALIA - Serie B" });
                _dataContext.Leagues.Add(new League { Name = "FRANCIA - Ligue 1" });
                _dataContext.Leagues.Add(new League { Name = "FRANCIA - Ligue 2" });
                _dataContext.Leagues.Add(new League { Name = "HOLANDA - Eredivisie" });                
                _dataContext.Leagues.Add(new League { Name = "ARABIA - Saudi League" });
                _dataContext.Leagues.Add(new League { Name = "ARGENTINA - Saf" });
                _dataContext.Leagues.Add(new League { Name = "AUSTRIA - Österreichische Fußball-Bundesliga" });
                _dataContext.Leagues.Add(new League { Name = "AUTRALIA - Hyundai A-League" });
                _dataContext.Leagues.Add(new League { Name = "BELGICA - Belgium Pro League" });
                _dataContext.Leagues.Add(new League { Name = "CHILE - Campeonato Scotiabank" });
                _dataContext.Leagues.Add(new League { Name = "CHINA - CLS" });
                _dataContext.Leagues.Add(new League { Name = "COLOMBIA - Liga Dimayor" });
                _dataContext.Leagues.Add(new League { Name = "CROACIA - Liga Hrvatska" });
                _dataContext.Leagues.Add(new League { Name = "DINAMARCA - Danish Superliga" });
                _dataContext.Leagues.Add(new League { Name = "ESCOCIA - Scotish Premier" });                
                _dataContext.Leagues.Add(new League { Name = "FILANDIA - Finnliiga" });
                _dataContext.Leagues.Add(new League { Name = "GRECIA - Hellas Liga" });
                _dataContext.Leagues.Add(new League { Name = "IRLANDA - SSE Airtricity League" });
                _dataContext.Leagues.Add(new League { Name = "JAPON - J League" });
                _dataContext.Leagues.Add(new League { Name = "MEXICO - Liga Bancomer MX" });
                _dataContext.Leagues.Add(new League { Name = "NORUEGA - Eliteserien" });
                _dataContext.Leagues.Add(new League { Name = "POLONIA - Ekstraklasa" });
                _dataContext.Leagues.Add(new League { Name = "PORTUGAL - Liga NOS" });
                _dataContext.Leagues.Add(new League { Name = "REP. CHECA - Česká Liga" });
                _dataContext.Leagues.Add(new League { Name = "RUSIA - League of Russia" });
                _dataContext.Leagues.Add(new League { Name = "SUECIA - Allsvenskan" });
                _dataContext.Leagues.Add(new League { Name = "TURQUIA - Super Lig" });
                _dataContext.Leagues.Add(new League { Name = "UCRANIA - Ukraine Liga" });
                _dataContext.Leagues.Add(new League { Name = "USA - MLS" });

                await _dataContext.SaveChangesAsync();
            }
        }






        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }

        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.UserManagers.Any())
            {
                _dataContext.UserManagers.Add(new UserManager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
