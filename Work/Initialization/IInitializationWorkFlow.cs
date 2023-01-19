using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Models_and_repositories.CommonRepository;
using DatabaseHandler.Models_and_repositories.Role;
using DatabaseHandler.Models_and_repositories.Role.RoleRepository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Work.Initialization
{
    public interface IInitializationWorkFlow : IDisposable
    {

        public ICommonGenericRepository<Department> _departmentHandlingRepository { get; }
        public ICommonGenericRepository<Level_Term> _levelTermRepository { get; }
        public IRoleRepository _roleRepository { get; }
        public int Complete();
        public void Dispose();
    }
}
