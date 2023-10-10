using LabMedicineAPI.Infra;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LabMedicineAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LabMedicineDbContext _context;

        public Repository(LabMedicineDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public TEntity GetByUser(Expression<Func<TEntity, bool>> user)
        {
            try
            {
                return _context.Set<TEntity>().FirstOrDefault(user);
            }
            catch (Exception ex)
            {

                throw new Exception("Email e ou senha incorretos", ex);
            }
        }

    }
}
