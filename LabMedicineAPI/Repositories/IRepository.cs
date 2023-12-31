﻿using System.Linq.Expressions;

namespace LabMedicineAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(int id);
        TEntity GetByUser(Expression<Func<TEntity, bool>> criteria);
        TEntity GetByPacienteId(int pacienteId);
    }

}
