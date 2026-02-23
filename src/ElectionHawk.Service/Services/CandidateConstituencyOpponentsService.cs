using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class CandidateConstituencyOpponentsService : ServiceBase, ICandidateConstituencyOpponentsService
    {
        private readonly ICandidateConstituencyOpponentsRepository _candidateConstituencyOpponentsRepository;

        public CandidateConstituencyOpponentsService(ICandidateConstituencyOpponentsRepository candidateConstituencyOpponentsRepository)
        {
            this._candidateConstituencyOpponentsRepository = candidateConstituencyOpponentsRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.CandidateConstituencyOpponentsEntity> GetByIdAsync(int id)
        {
            return await this._candidateConstituencyOpponentsRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.CandidateConstituencyOpponentsEntity>> GetAllAsync()
        {
            return await this._candidateConstituencyOpponentsRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.CandidateConstituencyOpponentsEntity entityToInsert)
        {
            try
            {
                await this._candidateConstituencyOpponentsRepository.InsertAsync(entityToInsert);
                return entityToInsert.OpponentProfileId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.CandidateConstituencyOpponentsEntity entityToUpdate)
        {
            try
            {
                return await this._candidateConstituencyOpponentsRepository.UpdateAsync(entityToUpdate);

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
                return await this._candidateConstituencyOpponentsRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
