using System;
using System.Collections.Generic;
using System.Text;
using ElectionHawk.Common.Interfaces;
using ElectionHawk.Common.AppSettings;
using Dapper;
using Dapper.FastCrud;
using System.Threading.Tasks;
using entity = ElectionHawk.Common.Entities;

namespace ElectionHawk.Repository
{
    
    public class TeamTaskRepository : RepositoryBase, ITeamTaskRepository
    {
       public TeamTaskRepository(ConnectionString connectionString) : base(connectionString) { }
        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.TeamTaskEntity> GetByIdAsync(int id)
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.GetAsync<entity.TeamTaskEntity>(new entity.TeamTaskEntity { TeamTaskId = id });
            }
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.TeamTaskEntity>> GetAllAsync()
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.FindAsync<entity.TeamTaskEntity>();
            }
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
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    await connection.InsertAsync(entityToInsert);
                    return entityToInsert.TeamTaskId;
                }
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
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.UpdateAsync(entityToUpdate);
                }
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
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.DeleteAsync<entity.TeamTaskEntity>(new entity.TeamTaskEntity { TeamTaskId = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
