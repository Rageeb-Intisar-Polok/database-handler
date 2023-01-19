using DatabaseHandler.Models;
using DatabaseHandler.Models_and_repositories.Role;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDBHandler.Models.User.User_Types
{
    public class Officials
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficialNo { get; set; }
        public int RoleId { get; set; }
        public Role role { get; set; }
        public int IndividualId { get; set; }
        public Users Individual { get; set; }
        public string[] getdetails()
        {
            string[] details = new string[1];
            details[0] = role.RoleName.ToString() ;
            return details;
        }  
    }
}
