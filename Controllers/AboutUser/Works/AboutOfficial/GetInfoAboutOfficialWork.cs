using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Models_and_repositories.Role;
using DatabaseHandler.Models_and_repositories.Role.RoleRepository;
using DatabaseHandler.Models_and_repositories.User.User_Types.UserTypeRepositories.Official_Repository;
using DatabaseHandler.VisibleModels_to_addNewUser.Users;

namespace DatabaseHandler.Controllers.AboutUser.Works.AboutOfficial
{
    public class GetInfoAboutOfficialWork : IGetInfoAboutOfficialWork
    {
        private IOfficialRepository _officialRepository;
        private IRoleRepository _roleRepository;
        public GetInfoAboutOfficialWork(IOfficialRepository officialRepository, IRoleRepository roleRepository)
        {
            _officialRepository = officialRepository;
            _roleRepository = roleRepository;
        }
        public Visible_official getVisibleOfficial(int individualId)
        {
            int id = individualId;
            Officials official = _officialRepository.GetOfficialByUniqueId(id);


            Visible_official visible_Official = new Visible_official();
            Role role;
            int roleId = official.RoleId;
            role = _roleRepository.getRoleId(roleId);
            string roleName = role.RoleName;
            visible_Official.Role = roleName;


            return visible_Official;
        }
    }
}
