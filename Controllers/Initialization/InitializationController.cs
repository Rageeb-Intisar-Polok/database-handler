using AdminDBHandler.Models.Dept_Level_Term;
using CoreApiResponse;
using DatabaseHandler.Models_and_repositories.Role;
using DatabaseHandler.Work.Initialization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHandler.Controllers.Initialization
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitializationController : BaseController
    {
        InitializationDetailsModel _model;
        IInitializationWorkFlow _workFlow;
        public InitializationController(IInitializationWorkFlow workFlow)
        {
            _workFlow = workFlow;
        }

        [HttpPost]
        public IActionResult initialConfiguration([FromBody] InitializationDetailsModel model)
        {
            try
            {
                _model = model;

                HashSet<Department> depts = new HashSet<Department>();
                HashSet<string> textDepts = _model.departments;
                

                foreach(string x in textDepts)
                {
                    Department dept = new Department();
                    dept.DeptName = x;
                    depts.Add(dept);

                }
                _workFlow._departmentHandlingRepository.AddSome(depts);

                List<Level_Term> levelTerms = new List<Level_Term>();
                int _levelCount = _model.level_count;
                SortedSet<string> terms = new SortedSet<string>();

                terms = _model.terms;

                for(int a = 1; a <= _levelCount; a++)
                {
                    foreach(string x in terms)
                    {
                        Level_Term levelTerm = new Level_Term();
                        levelTerm.Level = a;
                        levelTerm.Term = x;

                        levelTerms.Add(levelTerm);
                    }
                }
                _workFlow._levelTermRepository.AddSome(levelTerms);



                SortedSet<string> textRoles = _model.roles;
                List<Role> roles = new List<Role>();
                foreach(string x in textRoles)
                {
                    Role role = new Role();
                    role.RoleName = x;
                    roles.Add(role);
                }
                _workFlow._roleRepository.AddSome(roles);

                _workFlow.Complete();
                return CustomResult("Data uploaded successfully.",System.Net.HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                _workFlow.Dispose();
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
