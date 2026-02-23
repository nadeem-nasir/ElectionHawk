using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;



namespace ElectionHawk.Service.Interfaces
{
   
    public interface ITargetCommunityService:IServiceBase
    {
        Task<int?> InsertAsync(entity.TargetCommunityEntity entityToInsert);
        Task<entity.TargetCommunityEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.TargetCommunityEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.TargetCommunityEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
