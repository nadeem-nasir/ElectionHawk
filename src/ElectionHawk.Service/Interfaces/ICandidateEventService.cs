using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    
    public interface ICandidateEventService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateEventEntity entityToInsert);
        Task<entity.CandidateEventEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateEventEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateEventEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);

    }
}
