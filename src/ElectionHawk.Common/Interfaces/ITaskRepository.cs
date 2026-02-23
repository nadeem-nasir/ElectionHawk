using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Common.Interfaces
{
    
    public interface ITaskRepository
    {
        Task<int?> InsertAsync(entity.TaskEntity entityToInsert);
        Task<entity.TaskEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.TaskEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.TaskEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
