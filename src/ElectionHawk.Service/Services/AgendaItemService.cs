using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class AgendaItemService : ServiceBase, IAgendaItemService
    {
        private readonly IAgendaItemRepository _agendaItemRepository;

        public AgendaItemService(IAgendaItemRepository agendaItemRepository)
        {
            this._agendaItemRepository = agendaItemRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.AgendaItemEntity> GetByIdAsync(int id)
        {
            return await this._agendaItemRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.AgendaItemEntity>> GetAllAsync()
        {
            return await this._agendaItemRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.AgendaItemEntity entityToInsert)
        {
            try
            {
                await this._agendaItemRepository.InsertAsync(entityToInsert);
                return entityToInsert.ItemId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.AgendaItemEntity entityToUpdate)
        {
            try
            {
                return await this._agendaItemRepository.UpdateAsync(entityToUpdate);

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
                return await this._agendaItemRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
