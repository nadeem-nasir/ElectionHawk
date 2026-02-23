using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingStationBoothResultService : ServiceBase, IPollingStationBoothResultService
    {
        private readonly IPollingStationBoothResultRepository _pollingStationBoothResultRepository;

        public PollingStationBoothResultService(IPollingStationBoothResultRepository pollingStationBoothResultRepository)
        {
            this._pollingStationBoothResultRepository = pollingStationBoothResultRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingStationBoothResultEntity> GetByIdAsync(int id)
        {
            return await this._pollingStationBoothResultRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingStationBoothResultEntity>> GetAllAsync()
        {
            return await this._pollingStationBoothResultRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingStationBoothResultEntity entityToInsert)
        {
            try
            {
                await this._pollingStationBoothResultRepository.InsertAsync(entityToInsert);
                return entityToInsert.PollingBoothResultId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingStationBoothResultEntity entityToUpdate)
        {
            try
            {
                return await this._pollingStationBoothResultRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingStationBoothResultRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
