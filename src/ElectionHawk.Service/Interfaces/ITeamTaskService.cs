using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Service.Interfaces
{
    
    public interface ITeamTaskService:IServiceBase
    {
        Task<int?> InsertAsync(entity.TeamTaskEntity entityToInsert);
        Task<entity.TeamTaskEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.TeamTaskEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.TeamTaskEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
