using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Data;

namespace AL.Events.DAL.Repositories.Implementations
{
    class RoleRepository : IRepository<Role>
    {
        private readonly ICustomLogger _customLogger;
        private readonly ISqlFactory _sqlFactory;

        public RoleRepository(ICustomLogger logger, ISqlFactory sqlFactory)
        {
            _customLogger = logger;
            _sqlFactory = sqlFactory;
        }

        public void Create(Role item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Role> GetAll()
        {
            var collection = new List<Role>();

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetRolesList, connection, CommandType.StoredProcedure))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var role = new Role()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            };

                            collection.Add(role);
                        }
                    }
                }
            }

            return collection;
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
