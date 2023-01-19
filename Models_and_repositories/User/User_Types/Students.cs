using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AdminDBHandler.Models.User.User_Types
{
    public class Students
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentNo { get; set; }
        public int IndividualId { get; set; }
        public Users Individual { get; set; }
        public int DeptId { get; set; }
        public Department Dept { get; set; }
        public int LTId { get; set; }
        public Level_Term LT { get; set; }

        public string[] getdetails()
        {
            string[] details = new string[3];
            details[0] = Dept.DeptName;
            details[1] = LT.Level.ToString();
            details[2] = LT.Term;
            return details;
        }  
    }
}
