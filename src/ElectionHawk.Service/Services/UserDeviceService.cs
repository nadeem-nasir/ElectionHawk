using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class UserDeviceService : ServiceBase, IUserDeviceService
    {
        private readonly IUserDeviceRepository _userDeviceRepository;

        public UserDeviceService(IUserDeviceRepository userDeviceRepository)
        {
            this._userDeviceRepository = userDeviceRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.UserDeviceEntity> GetByIdAsync(int id)
        {
            return await this._userDeviceRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.UserDeviceEntity>> GetAllAsync()
        {
            return await this._userDeviceRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.UserDeviceEntity entityToInsert)
        {
            try
            {
                await this._userDeviceRepository.InsertAsync(entityToInsert);
                return entityToInsert.IdentityUserId;//userDeviceId?
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.UserDeviceEntity entityToUpdate)
        {
            try
            {
                return await this._userDeviceRepository.UpdateAsync(entityToUpdate);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Delete 
        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                return await this._userDeviceRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
