using PizzeriaButikenOnline.Core.Models;

namespace PizzeriaButikenOnline.Core.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(string id);
    }
}