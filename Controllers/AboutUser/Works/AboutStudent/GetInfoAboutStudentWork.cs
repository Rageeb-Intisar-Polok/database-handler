using AdminDBHandler.Models.Dept_Level_Term;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.LevelTermRepository;
using DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Student_Repository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;

namespace DatabaseHandler.Controllers.AboutUser.Works.AboutStudent
{
    public class GetInfoAboutStudentWork : IGetInfoAboutStudentWork
    {
        private IStudentRepository _studentRepository;
        private IDepartmentRepository _deptRepository;
        private ILevelTermRepository _levelTermRepository;
        public GetInfoAboutStudentWork(IStudentRepository studentRepository,
            IDepartmentRepository deptRepository, ILevelTermRepository levelTermRepository)
        {
            _studentRepository = studentRepository;
            _deptRepository = deptRepository;
            _levelTermRepository = levelTermRepository;
        }

        public Visible_student getVisibleStudent(int individualId)
        {
            int id = individualId;
            Students student = _studentRepository.GetStudentByUniqueId(id);


            Visible_student visible_Student = new Visible_student();
            Department dept;
            int deptId = student.DeptId;
            dept = _deptRepository.getDepartmentById(deptId);
            string a = dept.DeptName;
            visible_Student.Dept = a;
            int levelId = student.LTId;
            Level_Term lt = _levelTermRepository.getLevelTermById(levelId);
            visible_Student.level = lt.Level;
            visible_Student.term = lt.Term;


            return visible_Student;
        }
    }
}
