using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{

    public interface ICandidateNewsService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CandidateNewsEntity entityToInsert);
        Task<entity.CandidateNewsEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CandidateNewsEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CandidateNewsEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
