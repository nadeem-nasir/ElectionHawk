using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service.Interfaces
{

    public interface IUserDeviceService:IServiceBase
    {
        Task<int?> InsertAsync(entity.UserDeviceEntity entityToInsert);
        Task<entity.UserDeviceEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.UserDeviceEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.UserDeviceEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
    }
}
