using AdminDBHandler.Models.User.User_Types;

namespace DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Student_Repository
{
    public interface IStudentRepository
    {
        public Students GetStudentByUniqueId(int individualId);
    }
}
