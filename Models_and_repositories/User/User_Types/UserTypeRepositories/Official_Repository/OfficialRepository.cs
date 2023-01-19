using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Context;

namespace DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Official_Repository
{
    public class OfficialRepository : IOfficialRepository
    {
        private ApplicationDbContext _context;
        public OfficialRepository(ApplicationDbContext context)
        {
            _context= context;
        }
        public Officials GetOfficialByUniqueId(int individualId)
        {
            Officials t = _context.officials.Where(x => x.IndividualId == individualId).FirstOrDefault();
            return t;
        }
    }
}
