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
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
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
                            var organizer = new Organizer()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Phones = (string)reader["Phones"],
                                Email = (string)reader["Email"]
                            };
                            collection.Add(organizer);
                        }
                    }
                }
            }

            return collection;
        }

        public Organizer GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Organizer item)
        {
            throw new System.NotImplementedException();
        }
    }
}
