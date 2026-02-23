using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;


namespace ElectionHawk.Service.Interfaces
{
    
    public interface IVoterListDetailService:IServiceBase
    {
        Task<int?> InsertAsync(entity.VoterListDetailEntity entityToInsert);
        Task<entity.VoterListDetailEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.VoterListDetailEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.VoterListDetailEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
