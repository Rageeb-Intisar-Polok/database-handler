using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;

namespace DatabaseHandler.Controllers.AboutUser.Works.AboutTeacher
{
    public interface IGetInfoAboutTeacherWork
    {
        public Visible_teacher getVisibleTeacher(int individualId);
    }
}
