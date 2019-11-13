using MyPersonalWeb.Web.Data;
using MyPersonalWeb.Web.Data.Entities;
using MyPersonalWeb.Web.Models;
using System.Threading.Tasks;

namespace MyPersonalWeb.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;        

        public ConverterHelper(DataContext dataContext)
        {
            _dataContext = dataContext;            
        }

        public async Task<Team> ToTeamAsync(TeamViewModel model, bool isNew)
        {
            var team = new Team
            {
                TeamId = isNew ? 0 : model.TeamId,
                Name = model.Name,
                League = await _dataContext.Leagues.FindAsync(model.LeagueId)
            };

            return team;
        }

        public TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel
            {
                Name = team.Name,
                League = team.League,
                TeamId = team.TeamId,
                LeagueId = team.League.LeagueId,
                LeagueName = team.League.Name
            };
        }
    }
}
