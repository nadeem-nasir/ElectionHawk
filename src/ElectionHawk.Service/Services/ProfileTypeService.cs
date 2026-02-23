using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class ProfileTypeService : ServiceBase, IProfileTypeService
    {
        private readonly IProfileTypeRepository _profileTypeRepository;

        public ProfileTypeService(IProfileTypeRepository profileTypeRepository)
        {
            this._profileTypeRepository = profileTypeRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ProfileTypeEntity> GetByIdAsync(int id)
        {
            return await this._profileTypeRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ProfileTypeEntity>> GetAllAsync()
        {
            return await this._profileTypeRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ProfileTypeEntity entityToInsert)
        {
            try
            {
                await this._profileTypeRepository.InsertAsync(entityToInsert);
                return entityToInsert.ProfileTypeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ProfileTypeEntity entityToUpdate)
        {
            try
            {
                return await this._profileTypeRepository.UpdateAsync(entityToUpdate);

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
                return await this._profileTypeRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
