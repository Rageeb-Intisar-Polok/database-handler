using AdminDBHandler.Models.Dept_Level_Term;
using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using CoreApiResponse;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;
using DatabaseHandler.Work.AddUser;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers.AddNewUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewTeacherController : BaseController
    {
        private readonly IAddUserUnitOfWork<Teachers> _addNewTeacher;
        private readonly IDepartmentRepository _deptRepository;
        private HashSet<Visible_teacher> _newUsers;
        private Users _user;
        private Teachers _teacher;
        public AddNewTeacherController(IAddUserUnitOfWork<Teachers> addNewTeacher,
            IDepartmentRepository deptRepository)
        {
            _addNewTeacher = addNewTeacher;
            _deptRepository = deptRepository;
        }
        [HttpPost]
        public IActionResult NewTeacher([FromBody] HashSet<Visible_teacher> newUsers)
        {
            try
            {
                _newUsers = newUsers;
                foreach(var _newUser in _newUsers)
                {
                    _user = new Users();
                    _teacher = new Teachers();

                    _user.ID = _newUser.ID;
                    _user.Name = _newUser.Name;
                    _user.UserType = "teacher";
                    _user.Phone = _newUser.Phone;
                    _user.Email = _newUser.Email;


                    _addNewTeacher.user.Add(_user);
                    _teacher.Individual = _user;

                    Department dept = _deptRepository.getDeptByName(_newUser.Dept);
                    _teacher.Dept = dept;
                    _teacher.Designation = _newUser.Designation;

                    _addNewTeacher.SpecificTypeUser.Add(_teacher);
                }

                
                _addNewTeacher.Complete();

                return CustomResult("Teacher's data is uploaded successfully");
            }
            catch (Exception ex)
            {
                _addNewTeacher.Dispose();
                return BadRequest(ex.Message);
            }
        }
    }
}
