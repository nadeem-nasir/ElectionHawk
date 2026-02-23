using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{

    public interface ICandidateCampaignRepository
    {
        Task<int?> InsertAsync(entity.CandidateCampaignEntity entityToInsert);
        Task<entity.CandidateCampaignEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateCampaignEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateCampaignEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
