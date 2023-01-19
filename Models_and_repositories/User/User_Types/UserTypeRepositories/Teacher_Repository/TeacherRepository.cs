using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Teacher_Repository
{
    public class TeacherRepository : CommonGenericRepository<Teachers>, ITeacherRepository
    {
        private ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Teachers GetTeacherByUniqueId(int individualId)
        {
            Teachers t = _context.teachers.Where(x => x.IndividualId == individualId).FirstOrDefault();
            return t;
        }

    }
}
