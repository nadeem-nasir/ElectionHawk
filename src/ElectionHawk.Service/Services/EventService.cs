using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class EventService : ServiceBase, IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.EventEntity> GetByIdAsync(int id)
        {
            return await this._eventRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.EventEntity>> GetAllAsync()
        {
            return await this._eventRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.EventEntity entityToInsert)
        {
            try
            {
                await this._eventRepository.InsertAsync(entityToInsert);
                return entityToInsert.EventId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.EventEntity entityToUpdate)
        {
            try
            {
                return await this._eventRepository.UpdateAsync(entityToUpdate);

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
                return await this._eventRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
