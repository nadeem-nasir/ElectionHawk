using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateCampaignService : ServiceBase, ICandidateCampaignService
    {
        private readonly ICandidateCampaignRepository _candidateCampaignRepository;

        public CandidateCampaignService(ICandidateCampaignRepository candidateCampaignRepository)
        {
            this._candidateCampaignRepository = candidateCampaignRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateCampaignEntity> GetByIdAsync(int id)
        {
            return await this._candidateCampaignRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateCampaignEntity>> GetAllAsync()
        {
            return await this._candidateCampaignRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateCampaignEntity entityToInsert)
        {
            try
            {
                await this._candidateCampaignRepository.InsertAsync(entityToInsert);
                return entityToInsert.CandidateCampaignId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateCampaignEntity entityToUpdate)
        {
            try
            {
                return await this._candidateCampaignRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateCampaignRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
