using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{

    public interface ICandidateCampaignVehicleService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateCampaignVehicleEntity entityToInsert);
        Task<entity.CandidateCampaignVehicleEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateCampaignVehicleEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateCampaignVehicleEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
