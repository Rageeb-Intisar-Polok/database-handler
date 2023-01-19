using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using CoreApiResponse;
using DatabaseHandler.Controllers.AboutUser.Works.AboutOfficial;
using DatabaseHandler.Controllers.AboutUser.Works.AboutStudent;
using DatabaseHandler.Controllers.AboutUser.Works.AboutTeacher;
using DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.LevelTermRepository;
using DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository;
using DatabaseHandler.Models_and_repositories.User.UserRepository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;
using DatabaseHandler.Work.GetToSendGenericUserDetails;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers.GetInformation
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAboutUserController : BaseController
    {
        IUserRepository _userRepository;

        IGetInfoAboutTeacherWork _getInfoAboutTeacherWork;
        IGetInfoAboutStudentWork _getInfoAboutStudentWork;
        IGetInfoAboutOfficialWork _getInfoAboutOfficialWork;
        
        Visible_teacher _visibleTeacher;
        Visible_student _visibleStudent;
        Visible_official _visibleOfficial;
        public GetAboutUserController(IUserRepository UserRepository,
            IGetInfoAboutTeacherWork getInfoAboutTeacherWork,
            IGetInfoAboutStudentWork getInfoAboutStudentWork,
            IGetInfoAboutOfficialWork getInfoAboutOfficialWork)
        {
            Console.WriteLine("inside controller of get aboutuser controller 1");
            _userRepository = UserRepository;
            _getInfoAboutTeacherWork = getInfoAboutTeacherWork;
            _getInfoAboutStudentWork= getInfoAboutStudentWork;
            _getInfoAboutOfficialWork= getInfoAboutOfficialWork;
            Console.WriteLine("inside controller of get aboutuser controller 1");
        }

        [HttpGet]
        public IActionResult AboutUser(string id)
        {
            try
            {                
                Console.WriteLine("inside AboutUser");

                Users user = _userRepository.GetById(id);

                if (user == null)
                {
                    return Ok("Not Found");
                }
                string type = user.UserType;
                string foundId = user.ID;

                Console.WriteLine("getAboutUserController line 56");

                if (type == "teacher")
                {
                    Console.WriteLine("getAboutUserController line 60");
                    int individualId = user.IndividualID;
                    _visibleTeacher = _getInfoAboutTeacherWork.getVisibleTeacher(individualId);
                    _visibleTeacher.Name = user.Name;
                    _visibleTeacher.Email = user.Email;
                    _visibleTeacher.Phone = user.Phone;
                    _visibleTeacher.ID = id;
                    Console.WriteLine("getAboutUserController line 67");
                    return CustomResult(_visibleTeacher);
                }
                else if(type == "student")
                {
                    Console.WriteLine("getAboutUserController line 72");
                    int individualId = user.IndividualID;
                    _visibleStudent = _getInfoAboutStudentWork.getVisibleStudent(individualId);
                    _visibleStudent.Name = user.Name;
                    _visibleStudent.Email = user.Email;
                    _visibleStudent.Phone = user.Phone;
                    _visibleStudent.ID = id;
                    Console.WriteLine("getAboutUserController line 79");
                    return CustomResult(_visibleStudent);
                }
                else if(type == "official")
                {
                    Console.WriteLine("getAboutUserController line 84");
                    int individualId = user.IndividualID;
                    _visibleOfficial = _getInfoAboutOfficialWork.getVisibleOfficial(individualId);
                    _visibleOfficial.Name = user.Name;
                    _visibleOfficial.Email = user.Email;
                    _visibleOfficial.Phone = user.Phone;
                    _visibleOfficial.ID = id;
                    Console.WriteLine("getAboutUserController line 91");
                    return CustomResult(_visibleOfficial);
                }
                else
                {
                    return CustomResult("Not Found",System.Net.HttpStatusCode.NotFound);
                }
                 
            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }  
    }
}
