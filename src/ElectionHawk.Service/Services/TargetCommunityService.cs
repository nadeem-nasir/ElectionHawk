using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class TargetCommunityService : ServiceBase, ITargetCommunityService
    {
        private readonly ITargetCommunityRepository _targetCommunityRepository;

        public TargetCommunityService(ITargetCommunityRepository targetCommunityRepository)
        {
            this._targetCommunityRepository = targetCommunityRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.TargetCommunityEntity> GetByIdAsync(int id)
        {
            return await this._targetCommunityRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.TargetCommunityEntity>> GetAllAsync()
        {
            return await this._targetCommunityRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.TargetCommunityEntity entityToInsert)
        {
            try
            {
                await this._targetCommunityRepository.InsertAsync(entityToInsert);
                return entityToInsert.CommunityId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.TargetCommunityEntity entityToUpdate)
        {
            try
            {
                return await this._targetCommunityRepository.UpdateAsync(entityToUpdate);

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
                return await this._targetCommunityRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
