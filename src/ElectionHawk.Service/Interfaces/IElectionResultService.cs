using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Service.Interfaces
{
   
    public interface IElectionResultService:IServiceBase
    {
        Task<int?> InsertAsync(entity.ElectionResultEntity entityToInsert);
        Task<entity.ElectionResultEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ElectionResultEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ElectionResultEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
