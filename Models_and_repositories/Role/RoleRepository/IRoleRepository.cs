using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.Role.RoleRepository
{
    public interface IRoleRepository : ICommonGenericRepository<Role>
    {
        public Role getByName(string name);
        public Role getRoleId(int id);
    }
}
