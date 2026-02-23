using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Common.Interfaces
{
   
    public interface ITeamRepository 
    {

        Task<int?> InsertAsync(entity.TeamEntity entityToInsert);
        Task<entity.TeamEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.TeamEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.TeamEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
