using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository;
using DatabaseHandler.Models_and_repositories.User.UserRepository;

namespace DatabaseHandler.Work.AddUser
{
    public interface IAddUserUnitOfWork<T> : IDisposable where T : class
    {
        public IUserTypeGenericRepository<T> SpecificTypeUser { get; }
        public IUserRepository user { get; }
        public int Complete();
    }
}
