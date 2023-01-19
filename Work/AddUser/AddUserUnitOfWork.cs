//    ICommonUserType

using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository;
using DatabaseHandler.Models_and_repositories.User.UserRepository;

namespace DatabaseHandler.Work.AddUser
{
    public class AddUserUnitOfWork<T> : IAddUserUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public AddUserUnitOfWork(ApplicationDbContext context, IUserTypeGenericRepository<T> specificTypeUser, IUserRepository user)
        {
            _context = context;
            SpecificTypeUser = specificTypeUser;
            this.user = user;
        }


        public IUserTypeGenericRepository<T> SpecificTypeUser { get; private set; }
        public IUserRepository user { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
