using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Models_and_repositories.CommonRepository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository
{
   // public interface IUserTypeGenericRepository
    public interface IUserTypeGenericRepository<T> : ICommonGenericRepository<T> where T : class
    {
    //    public Teachers GetTeacherByUniqueId(Users user);
    //    public Officials GetOfficialByUniqueId(Users user);
     //   public Students GetStudentByUniqueId(Users user);
    //    public string[] GetDetailsByIdAndType(string type, Users user);
    /*    public Teachers GetTeacherById(string id);
        public Officials GetOfficialById(string id);
        public Students GetStudentById(string id);  */
    }
}
