using System;
using System.Collections.Generic;
using System.Data;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Infrastructure.Factories;

namespace AL.Events.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ICustomLogger _customLogger;
        private readonly ISqlFactory _sqlFactory;

        public UserRepository(ICustomLogger logger, ISqlFactory sqlFactory)
        {
            _customLogger = logger;
            _sqlFactory = sqlFactory;
        }

        public void Create(User item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Login", item.Login, DbType.String),
                _sqlFactory.CreateDbParameter("Password", item.Password, DbType.String),
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("LastName", item.LastName, DbType.String),
                _sqlFactory.CreateDbParameter("Email", item.Email, DbType.String),
                _sqlFactory.CreateDbParameter("RoleId", item.Role.Id, DbType.Int32)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.CreateUser, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Id", id, DbType.Int32)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.DeleteUserById, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<User> GetAll()
        {
            var collection = new List<User>();

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetUsersList, connection, CommandType.StoredProcedure))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = MapUserFromDbToBusiness(reader);

                            collection.Add(user);
                        }
                    }
                }
            }

            return collection;
        }

        public User GetById(int id)
        {
            User user = null;

            var parameter = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Id", id, DbType.Int32)
            };

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetUserById, connection, CommandType.StoredProcedure, parameter))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = MapUserFromDbToBusiness(reader);
                        }
                    }
                }
            }

            return user;
        }

        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Id", item.Id, DbType.Int32),
                _sqlFactory.CreateDbParameter("Login", item.Login, DbType.String),
                _sqlFactory.CreateDbParameter("Password", item.Password, DbType.String),
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("LastName", item.LastName, DbType.String),
                _sqlFactory.CreateDbParameter("Email", item.Email, DbType.String),
                _sqlFactory.CreateDbParameter("RoleId", item.Role.Id, DbType.Int32)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.UpdateUser, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        #region Mapper
        private User MapUserFromDbToBusiness(IDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Login = (string)reader["Login"],
                Password = (string)reader["Password"],
                Name = (string)reader["Name"],
                LastName = (string)reader["LastName"],
                Email = (string)reader["Email"],
                Role = new Role()
                {
                    Id = (int)reader["RoleId"],
                    Name = (string)reader["RoleName"]
                }
            };
        }
        #endregion
    }
}
