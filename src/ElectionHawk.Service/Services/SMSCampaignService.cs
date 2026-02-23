using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class SMSCampaignService : ServiceBase, ISMSCampaignService
    {
        private readonly ISMSCampaignRepository _sMSCampaignRepository;

        public SMSCampaignService(ISMSCampaignRepository sMSCampaignRepository)
        {
            this._sMSCampaignRepository = sMSCampaignRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.SMSCampaignEntity> GetByIdAsync(int id)
        {
            return await this._sMSCampaignRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.SMSCampaignEntity>> GetAllAsync()
        {
            return await this._sMSCampaignRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.SMSCampaignEntity entityToInsert)
        {
            try
            {
                await this._sMSCampaignRepository.InsertAsync(entityToInsert);
                return entityToInsert.SMSCampaignId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.SMSCampaignEntity entityToUpdate)
        {
            try
            {
                return await this._sMSCampaignRepository.UpdateAsync(entityToUpdate);

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
                return await this._sMSCampaignRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
