using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    
    public interface ISMSCampaignService:IServiceBase
    {
        Task<int?> InsertAsync(entity.SMSCampaignEntity entityToInsert);
        Task<entity.SMSCampaignEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.SMSCampaignEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.SMSCampaignEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
