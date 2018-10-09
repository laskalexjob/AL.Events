using AL.Events.Common.Entities;
using AL.Events.DAL.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Data;

namespace AL.Events.DAL.Repositories.Implementations
{
    internal class TestRepository : IRepository<Category>
    {
        private readonly ISqlFactory _sqlFactory;

        public TestRepository(ISqlFactory sqlFactory)
        {
            _sqlFactory = sqlFactory;
        }

        public void Create(Category item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("Id", item.Id, DbType.Int32)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand("SaveCategory", connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            var connection = _sqlFactory.CreateSqlConnection();


            List<Category> collection = new List<Category>();
            using (var command = _sqlFactory.CreateDbCommand("GetCategoriesList", connection, CommandType.StoredProcedure))
            {
                command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        collection.Add(new Category()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"]
                        });
                    }
                }
            }


            return collection;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
