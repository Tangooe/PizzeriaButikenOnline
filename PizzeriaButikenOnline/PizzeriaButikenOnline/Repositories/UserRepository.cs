using PizzeriaButikenOnline.Data;
using PizzeriaButikenOnline.Models;
using System.Linq;

namespace PizzeriaButikenOnline.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Name == id);
        }
    }
}
