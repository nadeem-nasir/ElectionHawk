using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateCampaignOfficeService : ServiceBase, ICandidateCampaignOfficeService
    {
        private readonly ICandidateCampaignOfficeRepository _candidateCampaignOfficeRepository;

        public CandidateCampaignOfficeService(ICandidateCampaignOfficeRepository candidateCampaignOfficeRepository)
        {
            this._candidateCampaignOfficeRepository = candidateCampaignOfficeRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateCampaignOfficeEntity> GetByIdAsync(int id)
        {
            return await this._candidateCampaignOfficeRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateCampaignOfficeEntity>> GetAllAsync()
        {
            return await this._candidateCampaignOfficeRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateCampaignOfficeEntity entityToInsert)
        {
            try
            {
                await this._candidateCampaignOfficeRepository.InsertAsync(entityToInsert);
                return entityToInsert.CampaignOfficeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateCampaignOfficeEntity entityToUpdate)
        {
            try
            {
                return await this._candidateCampaignOfficeRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateCampaignOfficeRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
