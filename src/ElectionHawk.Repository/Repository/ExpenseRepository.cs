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
    
    public class ExpenseRepository : RepositoryBase, IExpenseRepository
    {
        public ExpenseRepository(ConnectionString connectionString) : base(connectionString) { }
        #region Get and Find 

        /// <summary>
        /// get by Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<entity.ExpenseEntity> GetByIdAsync(int id)
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.GetAsync<entity.ExpenseEntity>(new entity.ExpenseEntity { ExpenseId = id });
            }
        }
        /// <summary>
        /// get all 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<entity.ExpenseEntity>> GetAllAsync()
        {
            try
            {
                var sql = @"select ex.ExpenseId, ex.AmountUtilized, ex.Balance,
                            ex.Description,  ex.ExpenseType, 
                            ex.TotalBudget, ex.EventId,ev.description, ex.ManagerProfileId, pr.ProfileId, pr.Name 
                            from expense ex inner join event ev on ev.eventId = ex.eventId 
                            inner join profile pr
                            on pr.profileId = ex.ManagerProfileId";

                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    
                    connection.Open();

                    return await connection.QueryAsync<entity.ExpenseEntity, entity.EventEntity, entity.ProfileEntity, entity.ExpenseEntity>(sql,
                        (ee, ev, pe) => {
                            ee.evt = ev;
                            ee.Profile = pe;
                            return ee;
                        }, splitOn:"EventId, ProfileId");

                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Insert 
        /// <summary>
        /// Insert new record 
        /// </summary>
        /// <param name="entityToInsert"></param>
        /// <returns></returns>
        public async Task<int?> InsertAsync(entity.ExpenseEntity entityToInsert)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    await connection.InsertAsync(entityToInsert);
                    return entityToInsert.ExpenseId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region update 
        public async Task<bool> UpdateAsync(entity.ExpenseEntity entityToUpdate)
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
                    return await connection.DeleteAsync<entity.ExpenseEntity>(new entity.ExpenseEntity { ExpenseId = id });
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
