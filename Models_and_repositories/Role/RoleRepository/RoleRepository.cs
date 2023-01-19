using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.Role.RoleRepository
{
    public class RoleRepository : CommonGenericRepository<Role>, IRoleRepository
    {
        ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Role getByName(string name)
        {
            Role role = _context.roles.Where(x => x.RoleName == name).FirstOrDefault();
            return role;
        }
        public Role getRoleId(int id)
        {
            return _context.roles.Find(id);
        }
    }
}
