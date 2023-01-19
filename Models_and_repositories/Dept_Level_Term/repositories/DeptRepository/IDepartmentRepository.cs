using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository
{
    public interface IDepartmentRepository : ICommonGenericRepository<Department>
    {
        public Department getDepartmentById(int id);
        public Department getDeptByName(string name);
        public SortedSet<Department> GetDepartments();
    }
}
