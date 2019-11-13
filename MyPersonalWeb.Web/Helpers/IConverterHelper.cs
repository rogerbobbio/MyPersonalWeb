using MyPersonalWeb.Web.Data.Entities;
using MyPersonalWeb.Web.Models;
using System.Threading.Tasks;

namespace MyPersonalWeb.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Team> ToTeamAsync(TeamViewModel model, bool isNew);
    }
}
