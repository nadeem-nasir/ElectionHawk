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
    public class UserDeviceRepository : RepositoryBase, IUserDeviceRepository
    {
        public UserDeviceRepository(ConnectionString connectionString) : base(connectionString) { }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.DeleteAsync<entity.UserDeviceEntity>(new entity.UserDeviceEntity { UserDeviceIdLocal = id});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<entity.UserDeviceEntity>> GetAllAsync()
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.FindAsync<entity.UserDeviceEntity>();
            }
        }

        

        public async Task<entity.UserDeviceEntity> GetByIdAsync(int id)
        {
            using (var connection = MyDapper.CreateConnection(GetConnectionString))
            {
                connection.Open();
                return await connection.GetAsync<entity.UserDeviceEntity>(new entity.UserDeviceEntity { UserDeviceIdLocal = id });
            }
        }

        public async Task<int?> InsertAsync(entity.UserDeviceEntity entityToInsert)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                     await connection.InsertAsync<entity.UserDeviceEntity>(entityToInsert);
                    return entityToInsert.UserDeviceIdLocal;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(entity.UserDeviceEntity entityToUpdate)
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


        public async Task<IEnumerable<entity.UserDeviceEntity>> GetByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.FindAsync<entity.UserDeviceEntity>(statement => statement
                    .Where($"{nameof(entity.UserDeviceEntity.UserPhoneNumber):C}=@UserPhoneNumber")
                    .WithParameters(new { UserPhoneNumber = phoneNumber }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<entity.UserDeviceEntity>> GetByIdentityUserIdAsync(int identityUserId)
        {

            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.FindAsync<entity.UserDeviceEntity>(statement => statement
                    .Where($"{nameof(entity.UserDeviceEntity.IdentityUserId):C}=@IdentityUserId")
                    .WithParameters(new { IdentityUserId = identityUserId }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<entity.UserDeviceEntity>> GetByUserTypesIdAsync(int userTypesId)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.FindAsync<entity.UserDeviceEntity>(statement => statement
                    .Where($"{nameof(entity.UserDeviceEntity.UserTypesId):C}=@UserTypesId")
                    .WithParameters(new { UserTypesId = userTypesId }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<entity.UserDeviceEntity>> GetByUserIdAsync(int userId)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.FindAsync<entity.UserDeviceEntity>(statement => statement
                    .Where($"{nameof(entity.UserDeviceEntity.UserId):C}=@UserId")
                    .WithParameters(new { UserId = userId }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<entity.UserDeviceEntity>> GetByUserDeviceTypeIdAsync(int userDeviceTypeId)
        {
            try
            {
                using (var connection = MyDapper.CreateConnection(GetConnectionString))
                {
                    connection.Open();
                    return await connection.FindAsync<entity.UserDeviceEntity>(statement => statement
                    .Where($"{nameof(entity.UserDeviceEntity.UserDeviceTypeId):C}=@UserDeviceTypeId")
                    .WithParameters(new { UserDeviceTypeId = userDeviceTypeId }));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
