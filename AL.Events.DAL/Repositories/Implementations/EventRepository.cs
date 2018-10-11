using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Data;

namespace AL.Events.DAL.Repositories.Implementations
{
    public class EventRepository : IRepository<Event>
    {
        private readonly ICustomLogger _customLogger;
        private readonly ISqlFactory _sqlFactory;

        public EventRepository(ICustomLogger logger, ISqlFactory sqlFactory)
        {
            _customLogger = logger;
            _sqlFactory = sqlFactory;
        }

        public void Create(Event item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("Date", item.Date, DbType.DateTime),
                _sqlFactory.CreateDbParameter("ImagePath", item.ImagePath, DbType.String),
                _sqlFactory.CreateDbParameter("Address", item.Address, DbType.String),
                _sqlFactory.CreateDbParameter("Description", item.Description, DbType.String),
                _sqlFactory.CreateDbParameter("Location", item.Location, DbType.String),
                _sqlFactory.CreateDbParameter("CategoryId", item.Category.Id, DbType.Int32),
                _sqlFactory.CreateDbParameter("OrganizerId", item.Organizer.Id, DbType.Int32),
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.CreateEvent, connection, CommandType.StoredProcedure, parameters))
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

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.DeleteEventByEventId, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<Event> GetAll()
        {
            List<Event> collection = new List<Event>();

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetEventsList, connection, CommandType.StoredProcedure))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var @event = new Event
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Date = (DateTime)reader["Date"],
                                ImagePath = (reader["ImagePath"] == DBNull.Value) ? null : (string)reader["ImagePath"],
                                Address = (string)reader["Address"],
                                Description = (string)reader["Description"],
                                Location = (string)reader["Location"],
                                Category = new Category()
                                {
                                    Id = (int)reader["CategoryId"],
                                    Name = (string)reader["CategoryName"]
                                },
                                Organizer = new Organizer()
                                {
                                    Id = (int)reader["OrganizerId"],
                                    Name = (string)reader["OrganizerName"],
                                    Phones = (string)reader["OrganizerPhones"],
                                    Email = (string)reader["OrganizerEmail"]
                                }
                            };
                            collection.Add(@event);
                        }
                    }
                }
            }

            return collection;
        }

        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event item)
        {
            throw new NotImplementedException();
        }
    }
}
