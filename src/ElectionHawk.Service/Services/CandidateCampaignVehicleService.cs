using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateCampaignVehicleService : ServiceBase, ICandidateCampaignVehicleService
    {
        private readonly ICandidateCampaignVehicleRepository _candidateCampaignVehicleRepository;

        public CandidateCampaignVehicleService(ICandidateCampaignVehicleRepository candidateCampaignVehicleRepository)
        {
            this._candidateCampaignVehicleRepository = candidateCampaignVehicleRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateCampaignVehicleEntity> GetByIdAsync(int id)
        {
            return await this._candidateCampaignVehicleRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateCampaignVehicleEntity>> GetAllAsync()
        {
            return await this._candidateCampaignVehicleRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateCampaignVehicleEntity entityToInsert)
        {
            try
            {
                await this._candidateCampaignVehicleRepository.InsertAsync(entityToInsert);
                return entityToInsert.CandidateProfileId;//actually candidatecampaignvehicleId?
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateCampaignVehicleEntity entityToUpdate)
        {
            try
            {
                return await this._candidateCampaignVehicleRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateCampaignVehicleRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
