using AdminDBHandler.Models.User.User_Types;

namespace DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Official_Repository
{
    public interface IOfficialRepository
    {
        public Officials GetOfficialByUniqueId(int individualId);
    }
}
