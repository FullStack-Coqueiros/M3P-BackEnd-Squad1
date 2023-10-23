using LabMedicineAPI.Infra;
using Microsoft.EntityFrameworkCore;


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
            
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        // Recarregua a entidade do banco de dados
        //        var databaseEntry = ex.Entries.Single();
        //        var databaseValues = databaseEntry.OriginalValues;
        //        var clientValues = (TEntity)ex.Entries.Single().Entity;

        //        // Verifique as propriedades alteradas pelo cliente e sobrescreva apenas essas no banco de dados
        //        foreach (var property in databaseValues.Properties)
        //        {
        //            var databaseValue = databaseValues[property];
        //            var clientValue = typeof(TEntity).GetProperty(property.Name).GetValue(clientValues);

        //            if (databaseValue != null && !databaseValue.Equals(clientValue))
        //            {
        //                // Somente sobrescreva as propriedades que foram modificadas pelo cliente
        //                databaseEntry.Property(property.Name).OriginalValue = databaseValue;
        //                databaseEntry.Property(property.Name).IsModified = true;
        //            }
        //        }

        //        // Agora tente salvar novamente
        //        _context.SaveChanges();
        //        return entity;
        //    }

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
    }

}
