using AdminDBHandler.Models.Dept_Level_Term;
using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using CoreApiResponse;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.LevelTermRepository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;
using DatabaseHandler.Work.AddUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers.AddNewUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewStudentController : BaseController
    {
        private readonly IAddUserUnitOfWork<Students> _addNewStudent;
        private HashSet<Visible_student> _newUsers;
        private IDepartmentRepository _deptRepository;
        private ILevelTermRepository _levelTermRepository;
        public AddNewStudentController(IAddUserUnitOfWork<Students> addNewStudent,
            IDepartmentRepository deptRepository, ILevelTermRepository levelTermRepository)
        {
            _addNewStudent = addNewStudent;
            _deptRepository = deptRepository;
            _levelTermRepository = levelTermRepository;
        }
        [HttpPost]
        public IActionResult NewOfficial([FromBody] HashSet<Visible_student> newUsers)
        {
            try
            {
                _newUsers = newUsers;
                foreach (var _newUser in _newUsers)
                {
                    Users user = new Users();
                    Students student = new Students();
                    user.ID = _newUser.ID;
                    user.Phone = _newUser.Phone;
                    user.Email = _newUser.Email;
                    user.Name = _newUser.Name;
                    user.UserType = "student";
                    Department department = _deptRepository.getDeptByName(_newUser.Dept);

                    int level = _newUser.level;
                    string term = _newUser.term;

                    Level_Term foundLt = _levelTermRepository.getLevelTermEntity(level, term);
                    student.LT = foundLt;
                    student.Dept = department;
                    _addNewStudent.user.Add(user);


                    int i_i_id = user.IndividualID;
                    student.Individual = user;


                    _addNewStudent.SpecificTypeUser.Add(student);
                }
                

                _addNewStudent.Complete();
                return CustomResult("Student's data uploaded successfully.");
            }
            catch (Exception ex)
            {
                _addNewStudent.Dispose();
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
