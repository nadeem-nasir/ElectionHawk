using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;



namespace ElectionHawk.Service.Interfaces
{
    
    public interface IConstituencyVoterListService:IServiceBase
    {
        Task<int?> InsertAsync(entity.ConstituencyVoterListEntity entityToInsert);
        Task<entity.ConstituencyVoterListEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.ConstituencyVoterListEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.ConstituencyVoterListEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
