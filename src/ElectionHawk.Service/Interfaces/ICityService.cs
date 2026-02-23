using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{
    
    public interface ICityService:IServiceBase
    {
        Task<int?> InsertAsync(entity.CityEntity entityToInsert);
        Task<entity.CityEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.CityEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.CityEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);


    }
}
