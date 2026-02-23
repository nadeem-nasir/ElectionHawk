using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Common.Interfaces
{

    public interface IUserDeviceRepository
    {
        Task<int?> InsertAsync(entity.UserDeviceEntity entityToInsert);
        Task<entity.UserDeviceEntity> GetByIdAsync(int id);
        Task<IEnumerable<entity.UserDeviceEntity>> GetAllAsync();
        Task<bool> UpdateAsync(entity.UserDeviceEntity entityToUpdate);
        Task<bool> DeleteByIdAsync(int id);
        //Task<IEnumerable<entity.UserDeviceEntity>> GetWhereAsync(string query, object filters);

        Task<IEnumerable<entity.UserDeviceEntity>> GetByPhoneNumberAsync(string phoneNumber);
        Task<IEnumerable<entity.UserDeviceEntity>> GetByIdentityUserIdAsync(int identityUserId);
        Task<IEnumerable<entity.UserDeviceEntity>> GetByUserTypesIdAsync(int userTypesId);
        Task<IEnumerable<entity.UserDeviceEntity>> GetByUserIdAsync(int userId);
        Task<IEnumerable<entity.UserDeviceEntity>> GetByUserDeviceTypeIdAsync(int userDeviceTypeId);

    }
}
