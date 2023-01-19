using AdminDBHandler.Models.Dept_Level_Term;
using DatabaseHandler.Context;
using DatabaseHandler.Models_and_repositories.CommonRepository;

namespace DatabaseHandler.Models_and_repositories.Dept_Level_Term.repositories.LevelTermRepository
{
    public class LevelTermRepository : CommonGenericRepository<Level_Term>, ILevelTermRepository
    {
        ApplicationDbContext _context;
        public LevelTermRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Level_Term getLevelTermEntity(int level, string term)
        {
            return _context.levelTerm.Where(a => (a.Level == level && a.Term == term)).FirstOrDefault();
        }
        public Level_Term getLevelTermById(int id)
        {
            return _context.levelTerm.Find(id);
        }
    }
}
