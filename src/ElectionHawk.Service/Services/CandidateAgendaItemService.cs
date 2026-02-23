using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateAgendaItemService : ServiceBase, ICandidateAgendaItemService
    {
        private readonly ICandidateAgendaItemRepository _candidateAgendaItemRepository;

        public CandidateAgendaItemService(ICandidateAgendaItemRepository candidateAgendaItemRepository)
        {
            this._candidateAgendaItemRepository = candidateAgendaItemRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateAgendaItemEntity> GetByIdAsync(int id)
        {
            return await this._candidateAgendaItemRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateAgendaItemEntity>> GetAllAsync()
        {
            return await this._candidateAgendaItemRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateAgendaItemEntity entityToInsert)
        {
            try
            {
                await this._candidateAgendaItemRepository.InsertAsync(entityToInsert);
                return entityToInsert.ItemId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateAgendaItemEntity entityToUpdate)
        {
            try
            {
                return await this._candidateAgendaItemRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateAgendaItemRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
