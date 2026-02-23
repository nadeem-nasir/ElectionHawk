using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
   

    public interface IEventRepository
    {
        Task<int?> InsertAsync(entity.EventEntity entityToInsert);
        Task<entity.EventEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.EventEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.EventEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
