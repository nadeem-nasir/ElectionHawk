using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PollingStationTokenAgentService : ServiceBase, IPollingStationTokenAgentService
    {
        private readonly IPollingStationTokenAgentRepository _pollingStationTokenAgentRepository;

        public PollingStationTokenAgentService(IPollingStationTokenAgentRepository pollingStationTokenAgentRepository)
        {
            this._pollingStationTokenAgentRepository = pollingStationTokenAgentRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PollingStationTokenAgentEntity> GetByIdAsync(int id)
        {
            return await this._pollingStationTokenAgentRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PollingStationTokenAgentEntity>> GetAllAsync()
        {
            return await this._pollingStationTokenAgentRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PollingStationTokenAgentEntity entityToInsert)
        {
            try
            {
                await this._pollingStationTokenAgentRepository.InsertAsync(entityToInsert);
                return entityToInsert.AgentProfileId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PollingStationTokenAgentEntity entityToUpdate)
        {
            try
            {
                return await this._pollingStationTokenAgentRepository.UpdateAsync(entityToUpdate);

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
                return await this._pollingStationTokenAgentRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
