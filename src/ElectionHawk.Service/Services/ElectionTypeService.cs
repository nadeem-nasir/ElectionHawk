using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class ElectionTypeService : ServiceBase, IElectionTypeService
    {
        private readonly IElectionTypeRepository _electionTypeRepository;

        public ElectionTypeService(IElectionTypeRepository electionTypeRepository)
        {
            this._electionTypeRepository = electionTypeRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ElectionTypeEntity> GetByIdAsync(int id)
        {
            return await this._electionTypeRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ElectionTypeEntity>> GetAllAsync()
        {
            return await this._electionTypeRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ElectionTypeEntity entityToInsert)
        {
            try
            {
                await this._electionTypeRepository.InsertAsync(entityToInsert);
                return entityToInsert.ElectionTypeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ElectionTypeEntity entityToUpdate)
        {
            try
            {
                return await this._electionTypeRepository.UpdateAsync(entityToUpdate);

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
                return await this._electionTypeRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
