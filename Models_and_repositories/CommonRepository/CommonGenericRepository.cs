using DatabaseHandler.Context;

namespace DatabaseHandler.Models_and_repositories.CommonRepository
{
    public class CommonGenericRepository<T> : ICommonGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public CommonGenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public string AddSome(IEnumerable<T> entities)
        {
            IEnumerable<T> _entities = entities;
            string to_return = "action undefined";
            try
            {
                foreach(var entity in _entities)
                {
                    _context.Set<T>().Add(entity);
                }
                to_return = "list added successfully";
            }
            catch(Exception ex)
            {
                to_return = ex.Message;
            }
            return to_return;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
