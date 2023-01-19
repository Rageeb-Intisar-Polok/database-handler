using AdminDBHandler.Models.User.User_Types;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Models_and_repositories.CommonRepository
{
    public interface ICommonGenericRepository<T> where T : class
    {
        public void Add(T entity);
        public string AddSome(IEnumerable<T> entities);

        public void Delete(T entity);

        public IEnumerable<T> GetAll();

        public void Update(T entity);


    }
}
