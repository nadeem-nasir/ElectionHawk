using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingStationInfoService : ServiceBase, IPollingStationInfoService
    {
        private readonly IPollingStationInfoRepository _pollingStationInfoRepository;

        public PollingStationInfoService(IPollingStationInfoRepository pollingStationInfoRepository)
        {
            this._pollingStationInfoRepository = pollingStationInfoRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingStationInfoEntity> GetByIdAsync(int id)
        {
            return await this._pollingStationInfoRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingStationInfoEntity>> GetAllAsync()
        {
            return await this._pollingStationInfoRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingStationInfoEntity entityToInsert)
        {
            try
            {
                await this._pollingStationInfoRepository.InsertAsync(entityToInsert);
                return entityToInsert.PollingStationId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingStationInfoEntity entityToUpdate)
        {
            try
            {
                return await this._pollingStationInfoRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingStationInfoRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
