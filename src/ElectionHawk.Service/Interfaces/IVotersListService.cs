using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
    
    public interface IVotersListService:IServiceBase
    {
        Task<int?> InsertAsync(entity.VotersListEntity entityToInsert);
        Task<entity.VotersListEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.VotersListEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.VotersListEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
