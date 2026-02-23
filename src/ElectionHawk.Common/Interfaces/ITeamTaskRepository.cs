using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Common.Interfaces
{
    
    public interface ITeamTaskRepository 
    {
        Task<int?> InsertAsync(entity.TeamTaskEntity entityToInsert);
        Task<entity.TeamTaskEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.TeamTaskEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.TeamTaskEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
