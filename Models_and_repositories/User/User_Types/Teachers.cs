using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminDBHandler.Models.User.User_Types
{
    public class Teachers
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherNo { get; set; }
        public int IndividualId { get; set; }
        public Users Individual { get; set; }
        public int DeptId { get; set; }
        public Department Dept { get; set; }
        public string Designation { get; set; } = "Unknown";
        //////public string[] getdetails(Department dept)
        //////{
        //////    string[] details = new string[2];
        //////    Console.WriteLine(Dept);
        //////    Console.WriteLine(Dept.DeptName.ToString());
        //////    details[0] = Dept.DeptName.ToString();
        //////    details[1] = Designation;
        //////    return details;
        //////}  
    }
}
