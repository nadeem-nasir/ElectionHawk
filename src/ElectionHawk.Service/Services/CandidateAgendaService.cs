using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateAgendaService : ServiceBase, ICandidateAgendaService
    {
        private readonly ICandidateAgendaRepository _candidateAgendaRepository;

        public CandidateAgendaService(ICandidateAgendaRepository candidateAgendaRepository)
        {
            this._candidateAgendaRepository = candidateAgendaRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateAgendaEntity> GetByIdAsync(int id)
        {
            return await this._candidateAgendaRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateAgendaEntity>> GetAllAsync()
        {
            return await this._candidateAgendaRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateAgendaEntity entityToInsert)
        {
            try
            {
                await this._candidateAgendaRepository.InsertAsync(entityToInsert);
                return entityToInsert.AgendaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateAgendaEntity entityToUpdate)
        {
            try
            {
                return await this._candidateAgendaRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateAgendaRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
