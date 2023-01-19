using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository
{
   // public class UserTypeGenericRepository:IUserTypeGenericRepository
    public class UserTypeGenericRepository<T> : CommonGenericRepository<T>, IUserTypeGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public UserTypeGenericRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        
        public Officials GetOfficialByUniqueId(Users user)
        {
            return _context.officials.Where(x => x.Individual == user).FirstOrDefault();
        }
        public Students GetStudentByUniqueId(Users user)
        {
            return _context.students.Where(x => x.Individual == user).FirstOrDefault();
        }
    /*    public string[] GetDetailsByIdAndType(string type, Users user)
        {
            if (type == "teacher")
            {
                return _context.teachers.Where(x => x.Individual == user).FirstOrDefault().getdetails();
            }
            else if (type == "official")
            {
                return _context.officials.Where(x => x.Individual == user).FirstOrDefault().getdetails();
            }
            else if (type == "student")
            {
                return _context.students.Where(x => x.Individual == user).FirstOrDefault().getdetails();
            }
            return null;
        } */
    }
}
