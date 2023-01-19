using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using CoreApiResponse;
using DatabaseHandler.Models_and_repositories.Role;
using DatabaseHandler.Models_and_repositories.Role.RoleRepository;
using DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;
using DatabaseHandler.Work.AddUser;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers.AddNewUserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddNewOfficialController : BaseController
    {
        private readonly IAddUserUnitOfWork<Officials> _addNewOfficial;
        private readonly IRoleRepository _roleRepository;
        private Users _baseInfo;
        private Officials _otherInfo;
        private HashSet<Visible_official> _newUsers;

        public AddNewOfficialController(IAddUserUnitOfWork<Officials> addNewOfficial,
            IRoleRepository roleRepository)
        {
            _addNewOfficial = addNewOfficial;
            _roleRepository = roleRepository;
            
        }

        [HttpPost]
        public IActionResult NewOfficial([FromBody] HashSet<Visible_official> newUsers)
        {
            try
            {
                _newUsers = newUsers;
                foreach (var _newUser in _newUsers)
                {
                    Role role = _roleRepository.getByName(_newUser.Role);


                    _baseInfo = new Users();
                    _otherInfo = new Officials();


                    _baseInfo.UserType = "official";
                    _baseInfo.Name = _newUser.Name;
                    _baseInfo.Phone = _newUser.Phone;
                    _baseInfo.Email = _newUser.Email;
                    _baseInfo.ID = _newUser.ID;


                    _otherInfo.role = role;

                    _addNewOfficial.user.Add(_baseInfo);


                    _otherInfo.Individual = _baseInfo;
                    _addNewOfficial.SpecificTypeUser.Add(_otherInfo);
                }


                _addNewOfficial.Complete();

                return CustomResult("Official's data is uploaded successfully");
            }
            catch(Exception ex)
            {
                _addNewOfficial.Dispose();
                return BadRequest(ex.Message);
            }
        }
    }   
}
