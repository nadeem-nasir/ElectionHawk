using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Service.Interfaces
{
   
    public interface ICandidateCampaignOfficeService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateCampaignOfficeEntity entityToInsert);
        Task<entity.CandidateCampaignOfficeEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateCampaignOfficeEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateCampaignOfficeEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
