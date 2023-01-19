/*
using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using CoreApiResponse;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using DatabaseHandler.Work.AddUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace DatabaseHandler.Controllers.AboutUser.ControllerForTesting
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewUserController : BaseController
    {
        
        private readonly IAddUserUnitOfWork<Officials> _addNewOfficial;
        private readonly IAddUserUnitOfWork<Teachers> _addNewTeacher;
        private readonly IAddUserUnitOfWork<Students> _addNewStudent;
        private string indicator;

        public NewUserController(IAddUserUnitOfWork<Officials> official, IAddUserUnitOfWork<Teachers> teacher, IAddUserUnitOfWork<Students> student)
        {
            _addNewOfficial = official;
            _addNewTeacher = teacher;
            _addNewStudent = student;
            indicator = "null";
        }

        [HttpPost]
        public IActionResult AddUser(string userType)
        {
            if(userType != "teacher" && userType != "student" && userType != "official")
            {
                return BadRequest();
            }
            var NewUser = new Users
            {
                ID = "180201100",
                Name = "Rageeb Intisar Polok",
                Email = "rageebintisarpolok@gmail.com",
                Phone = "01758654740",
                ConnectionListAndLastMessage_json = "nai apatoto"
            };

            bool checker = false;

            if (userType == "teacher")
            {
                try
                {
                    var NewTeacher = new Teachers
                    {
                        Individual = NewUser,
                        Designation = "Unknown"
                    };
                    checker = add_a_teacher(NewTeacher, NewUser);
                    _addNewOfficial.Complete();
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else if(userType == "student")
            {
                try
                {
                    var NewStudent = new Students
                    {
                        Individual = NewUser
                    };
                    checker = add_a_student(NewStudent, NewUser);
                    _addNewOfficial.Complete();
                }
                catch (Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            else if(userType == "official")
            {
                try
                {
                    var NewOfficial = new Officials
                    {
                        Role = "General",
                        Individual = NewUser
                    };
                    checker = add_an_official(NewOfficial, NewUser);
                    _addNewOfficial.Complete();
                }
                catch(Exception ex)
                {
                    return CustomResult(ex.Message, HttpStatusCode.BadRequest);
                }
            }
            return CustomResult("Data uploaded successfully");
        }

        private bool add_a_student(Students student, Users user)
        {
            try
            {
                _addNewStudent.user.Add(user);
                _addNewStudent.SpecificTypeUser.Add(student);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        private bool add_a_teacher(Teachers teacher, Users user)
        {
            try
            {
                _addNewTeacher.user.Add(user);
                _addNewTeacher.SpecificTypeUser.Add(teacher);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        private bool add_an_official(Officials official, Users user)
        {
            try
            {
                _addNewOfficial.user.Add(user);
                _addNewOfficial.SpecificTypeUser.Add(official);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        
    } 
}
 */