using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class UserManager
    {        
        public int Id { get; set; }

        public User User { get; set; }
    }
}
