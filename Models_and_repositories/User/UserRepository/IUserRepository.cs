using AdminDBHandler.Models.User;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.User.UserRepository
{
    public interface IUserRepository : ICommonGenericRepository<Users>
    {
        public Users? GetById(string id);
    }
}
