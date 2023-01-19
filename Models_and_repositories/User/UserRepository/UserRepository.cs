using AdminDBHandler.Models.User;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.User.UserRepository
{
    public class UserRepository : CommonGenericRepository<Users>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Users? GetById(string id)
        {
            Users? users = _context.users.Where(x => x.ID == id).FirstOrDefault(); ;
            return users;
        }
        
    }
}
