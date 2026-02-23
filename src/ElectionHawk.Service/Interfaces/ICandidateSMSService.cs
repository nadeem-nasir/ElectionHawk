using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{

    public interface ICandidateSMSService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateSMSEntity entityToInsert);
        Task<entity.CandidateSMSEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateSMSEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateSMSEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
