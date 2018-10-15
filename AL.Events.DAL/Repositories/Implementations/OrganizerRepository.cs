using System.Collections.Generic;
using System.Data;
using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Infrastructure.Factories;

namespace AL.Events.DAL.Repositories.Implementations
{
    public class OrganizerRepository : IRepository<Organizer>
    {
        private readonly ICustomLogger _customLogger;
        private readonly ISqlFactory _sqlFactory;

        public OrganizerRepository(ICustomLogger logger, ISqlFactory sqlFactory)
        {
            _customLogger = logger;
            _sqlFactory = sqlFactory;
        }

        public void Create(Organizer item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("Email", item.Email, DbType.String),
                _sqlFactory.CreateDbParameter("Phones", item.Phones, DbType.String)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.CreateOrganizer, connection, CommandType.StoredProcedure, parameters))
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

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.DeleteOrganizerByOrganizerId, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<Organizer> GetAll()
        {
            List<Organizer> collection = new List<Organizer>();

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetOrganizersList, connection, CommandType.StoredProcedure))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Organizer organizer = MapOrganizerFromDbToBusiness(reader);

                            collection.Add(organizer);
                        }
                    }
                }
            }

            return collection;
        }

        public Organizer GetById(int id)
        {
            Organizer organizer = null;

            var parameter = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Id", id, DbType.Int32)
            };

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetOrganizerByOrganizerId, connection, CommandType.StoredProcedure, parameter))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            organizer = MapOrganizerFromDbToBusiness(reader);
                        }
                    }
                }
            }

            return organizer;
        }

        public void Update(Organizer item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Id", item.Id, DbType.Int32),
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("Email", item.Email, DbType.String),
                _sqlFactory.CreateDbParameter("Phones", item.Phones, DbType.String)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.UpdateOrganizer, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private Organizer MapOrganizerFromDbToBusiness(IDataReader reader)
        {
            return new Organizer
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Email = (string)reader["Email"],
                Phones = (string)reader["Phones"]
            };
        }
    }
}
