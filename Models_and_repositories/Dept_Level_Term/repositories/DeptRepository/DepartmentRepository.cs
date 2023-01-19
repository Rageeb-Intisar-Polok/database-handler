using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.DeptRepository
{
    public class DepartmentRepository : CommonGenericRepository<Department> , IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Department getDepartmentById(int id)
        {
            Department _dept;
            _dept = _context.departments.Find(id);
            return _dept;
        }
        public Department getDeptByName(string name)
        {
            Department dept = _context.departments.Where(x => x.DeptName == name).First();
            return dept;
        }
        public SortedSet<Department> GetDepartments()
        {
            SortedSet<Department> depts = new SortedSet<Department>();
            depts = (SortedSet<Department>)GetAll();
            return depts;
        }
    }
}
