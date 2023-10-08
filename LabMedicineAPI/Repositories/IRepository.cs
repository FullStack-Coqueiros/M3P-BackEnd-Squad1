namespace LabMedicineAPI.Repositories
{
    public class IRepository
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            IEnumerable<TEntity> GetAll();
            TEntity GetById(int id);
            TEntity Create(TEntity entity);
            TEntity Update(TEntity entity);
            bool Delete(int id);
        }
    }
}
