using ElectionHawk.Common.Interfaces;
using ElectionHawk.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;
namespace ElectionHawk.Service
{
    public class TeamService : ServiceBase, ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository;
        }

        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.TeamEntity> GetByIdAsync(int id)
        {
            return await this._teamRepository.GetByIdAsync(id);
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.TeamEntity>> GetAllAsync()
        {
            return await this._teamRepository.GetAllAsync();

        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.TeamEntity entityToInsert)
        {
            try
            {
                await this._teamRepository.InsertAsync(entityToInsert);
                return entityToInsert.TeamId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.TeamEntity entityToUpdate)
        {
            try
            {
                return await this._teamRepository.UpdateAsync(entityToUpdate);

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
                return await this._teamRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
