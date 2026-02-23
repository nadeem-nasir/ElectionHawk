using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface ICandidateGroupsRepository
    {
        Task<int?> InsertAsync(entity.CandidateGroupsEntity entityToInsert);
        Task<entity.CandidateGroupsEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateGroupsEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateGroupsEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
