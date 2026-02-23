using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class TeamTaskService : ServiceBase, ITeamTaskService
    {
        private readonly ITeamTaskRepository _teamTaskRepository;

        public TeamTaskService(ITeamTaskRepository teamTaskRepository)
        {
            this._teamTaskRepository = teamTaskRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.TeamTaskEntity> GetByIdAsync(int id)
        {
            return await this._teamTaskRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.TeamTaskEntity>> GetAllAsync()
        {
            return await this._teamTaskRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.TeamTaskEntity entityToInsert)
        {
            try
            {
                await this._teamTaskRepository.InsertAsync(entityToInsert);
                return entityToInsert.TeamTaskId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.TeamTaskEntity entityToUpdate)
        {
            try
            {
                return await this._teamTaskRepository.UpdateAsync(entityToUpdate);

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
                return await this._teamTaskRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
