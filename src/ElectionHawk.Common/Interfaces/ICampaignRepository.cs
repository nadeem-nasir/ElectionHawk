using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{
    
    public interface ICampaignRepository 
    {
        Task<int?> InsertAsync(entity.CampaignEntity entityToInsert);
        Task<entity.CampaignEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CampaignEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CampaignEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
