using AdminDBHandler.Models.Dept_Level_Term;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository;
using DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Teacher_Repository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;

namespace DatabaseHandler.Controllers.AboutUser.Works.AboutTeacher
{
    public class GetInfoAboutTeacherWork : IGetInfoAboutTeacherWork
    {
        private ITeacherRepository _teacherRepository;
        private IDepartmentRepository _deptRepository;
        public GetInfoAboutTeacherWork(IDepartmentRepository deptRepository,
            ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
            _deptRepository = deptRepository;
        }
        public Visible_teacher getVisibleTeacher(int individualId)
        {
            int id = individualId;
            Teachers teacher =_teacherRepository.GetTeacherByUniqueId(id);
            Visible_teacher visible_Teacher = new Visible_teacher();
            Department dept;
            int deptId = teacher.DeptId;
            dept = _deptRepository.getDepartmentById(deptId);
            string a = dept.DeptName;
            visible_Teacher.Dept = a;
            visible_Teacher.Designation = teacher.Designation;
            return visible_Teacher;
        }
    }
}
