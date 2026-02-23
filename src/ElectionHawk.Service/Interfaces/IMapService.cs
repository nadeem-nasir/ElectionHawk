using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
    
    public interface IMapService:IServiceBase
    {
        Task<int?> InsertAsync(entity.MapEntity entityToInsert);
        Task<entity.MapEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.MapEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.MapEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
