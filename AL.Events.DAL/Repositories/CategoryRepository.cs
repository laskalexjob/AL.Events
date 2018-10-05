using AL.Events.Common.Entities;
using AL.Events.Common.Logger;
using AL.Events.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AL.Events.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ICustomLogger _customLogger;
        private readonly SqlConnection _connection;
        private readonly SqlDbContext _dbContext;

        public CategoryRepository(ICustomLogger logger)
        {
            _customLogger = logger;
            _dbContext = new SqlDbContext();
            _connection = _dbContext.GetConnection();
        }

        public void Create(Category item)
        {
            try
            {
                _connection.Open();
                var command = _dbContext.GetCommand(_connection, DbConstant.Command.SaveCategory);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = item.Id
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Name",
                    Value = item.Name
                });
                command.ExecuteNonQuery();
            }
            catch (Exception exeption)
            {
                _customLogger.WriteToLogInfo(exeption.Message);
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Open();
                var command = _dbContext.GetCommand(_connection, DbConstant.Command.DeleteCategoryByCategoryId);
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                });
                command.ExecuteNonQuery();

            }
            catch (Exception exeption)
            {
                _customLogger.WriteToLogInfo(exeption.Message);
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            try
            {
                _connection.Open();
                var command = _dbContext.GetCommand(_connection, DbConstant.Command.GetCategoriesList);
                var categoriesTable = _dbContext.CreateTable("Categories");
                categoriesTable = _dbContext.FillInTable(categoriesTable, command);
                var list = ParseToCategoryList(categoriesTable);
                return list;
            }
            catch (Exception exeption)
            {
                _customLogger.WriteToLogInfo(exeption.Message);
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }

        #region Parsers
        private List<Category> ParseToCategoryList(DataTable table)
        {
            var list = table.AsEnumerable().Select(m =>
            {
                return new Category()
                {
                    Id = m.Field<int>("Id"),
                    Name = m.Field<string>("Name")
                };
            }).ToList();
            return list;
        }
        #endregion
    }
}
