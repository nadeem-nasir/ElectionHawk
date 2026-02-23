using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class PartyOfficeService : ServiceBase, IPartyOfficeService
    {
        private readonly IPartyOfficeRepository _partyOfficeRepository;

        public PartyOfficeService(IPartyOfficeRepository partyOfficeRepository)
        {
            this._partyOfficeRepository = partyOfficeRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.PartyOfficeEntity> GetByIdAsync(int id)
        {
            return await this._partyOfficeRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.PartyOfficeEntity>> GetAllAsync()
        {
            return await this._partyOfficeRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.PartyOfficeEntity entityToInsert)
        {
            try
            {
                await this._partyOfficeRepository.InsertAsync(entityToInsert);
                return entityToInsert.PartyOfficeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.PartyOfficeEntity entityToUpdate)
        {
            try
            {
                return await this._partyOfficeRepository.UpdateAsync(entityToUpdate);

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
                return await this._partyOfficeRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
