using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Infrastructure.Factories;
using System.Collections.Generic;
using System.Data;

namespace AL.Events.DAL.Repositories.Implementations
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ICustomLogger _customLogger;
        private readonly ISqlFactory _sqlFactory;

        public CategoryRepository(ICustomLogger logger, ISqlFactory sqlFactory)
        {
            _customLogger = logger;
            _sqlFactory = sqlFactory;
        }

        public void Create(Category item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.CreateCategory, connection, CommandType.StoredProcedure, parameters))
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

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.DeleteCategoryByCategoryId, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Category GetById(int id)
        {
            Category category = null;

            var parameter = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Id", id, DbType.Int32)
            };

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetCategoryByCategoryId, connection, CommandType.StoredProcedure, parameter))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            };
                        }
                    }
                }
            }

            return category;
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            var collection = new List<Category>();

            using (var connection = _sqlFactory.CreateSqlConnection())
            {
                using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.GetCategoriesList, connection, CommandType.StoredProcedure))
                {
                    command.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           var category = new Category()
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"]
                            };

                            collection.Add(category);
                        }
                    }
                }
            }

            return collection;
        }

        public void Update(Category item)
        {
            var parameters = new List<IDataParameter>()
            {
                _sqlFactory.CreateDbParameter("Name", item.Name, DbType.String),
                _sqlFactory.CreateDbParameter("Id", item.Id, DbType.Int32)
            };

            var connection = _sqlFactory.CreateSqlConnection();

            using (var command = _sqlFactory.CreateDbCommand(DbConstant.Command.UpdateCategory, connection, CommandType.StoredProcedure, parameters))
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
