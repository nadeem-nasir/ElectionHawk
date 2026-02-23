using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    
    public interface IPoliticalPartyDesignationService:IServiceBase
    {
        Task<int?> InsertAsync(entity.PoliticalPartyDesignationEntity entityToInsert);
        Task<entity.PoliticalPartyDesignationEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.PoliticalPartyDesignationEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.PoliticalPartyDesignationEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
